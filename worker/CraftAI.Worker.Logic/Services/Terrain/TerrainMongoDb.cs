using Craft.AI.Worker.Interface.Network.Shared;
using CraftAI.Worker.Logic.Storage;
using CraftAI.Worker.Logic.Terrain;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.Services
{
	public class TerrainMongoDb : ITerrainService
	{
		private readonly World _world = new();
		private readonly Dictionary<Int3, ChunkMesh> _map = new();
		private readonly IMongoCollection<ChunkDocument> _chunks;
		public TerrainMongoDb(IConfiguration configuration)
		{
			MongoClient client = new MongoClient(configuration.GetConnectionString("MongoDB"));
			IMongoDatabase database = client.GetDatabase("Worker");
			_chunks = database.GetCollection<ChunkDocument>("Chunks");
			var indexKeysDefinition = Builders<ChunkDocument>.IndexKeys.Ascending(chunk => chunk.Positions);
			_chunks.Indexes.CreateOneAsync(new CreateIndexModel<ChunkDocument>(indexKeysDefinition));
		}

		public ValueTask<ChunkDocument> Get(int x, int y, int z)
		{
			var result = _chunks.Find(e => e.Positions == ChunkDocument.KeyFrom(x, y, z)).FirstOrDefault();
			return new ValueTask<ChunkDocument>(result);
		}

		public ValueTask<ChunkMesh> Get(short x, short y)
		{
			var key = new Int3(0, 4, 2);
			if (_map.ContainsKey(key)) return new ValueTask<ChunkMesh>(_map[key]);
			var result = _chunks.Find(e => e.Positions == ChunkDocument.KeyFrom(key.X, key.Y, key.Z)).FirstOrDefault();

			int[,,] data = new int[16, 16, 16];
			int index = 0;
			for (int xp = 0; xp < 16; xp++)
			{
				for (int yp = 0; yp < 16; yp++)
				{
					for (int zp = 0; zp < 16; zp++)
					{
						data[xp, yp, zp] = result.Data[index++];
					}
				}
			}
			var meshResult = new ChunkMesh(new ChunkCoord(key), _world, data);
			_map.Add(key, meshResult);
			return new ValueTask<ChunkMesh>(_map[key]);
		}

		public ValueTask Set(ChunkDocument chunk)
		{
			_chunks.FindOneAndDelete(e => e.Positions == chunk.Positions);
			_chunks.InsertOne(chunk);
			return ValueTask.CompletedTask;
		}
	}
}
