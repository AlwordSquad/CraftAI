using Craft.AI.Worker.Interface.Network.Shared;
using CraftAI.Gate.Service;
using CraftAI.Worker.Logic.Terrain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.Services
{
	internal class TerrainInMemory : ITerrainService
	{
		private readonly World _world = new();
		private readonly Dictionary<Int3, Chunk16x16x16> _map = new();

		public ValueTask<ChunkMesh> Get(short x, short y)
		{
			throw new System.NotImplementedException();
		}

		public ValueTask Set(Chunk16x16x16 chunk)
		{
			return ValueTask.CompletedTask;
			// throw new System.NotImplementedException();
		}
	}
}
