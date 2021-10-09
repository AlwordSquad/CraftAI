using CraftAI.Gate.Service;
using CraftAI.Worker.Logic.Terrain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.Services
{
	internal class TerrainDev : ITerrainService
	{
		private readonly World _world = new();
		private readonly Dictionary<ChunkCoord, ChunkMesh> _map = new();
		public ValueTask<ChunkMesh> Get(short chunkX, short chunkZ)
		{
			var coord = new ChunkCoord(chunkX, chunkZ);
			if (!_map.ContainsKey(coord))
			{
				byte[] heightPaletter = new byte[] { 0, 1, 2, 3, 4, 5 };
				byte[,,] _voxelMap = new byte[VoxelData.ChunkWidth, VoxelData.ChunkHeight, VoxelData.ChunkWidth];
				for (int x = 0; x < VoxelData.ChunkWidth; x++)
				{
					for (int y = 0; y < VoxelData.ChunkHeight - 1; y++)
					{
						for (int z = 0; z < VoxelData.ChunkWidth; z++)
						{
							_voxelMap[x, y, z] = y < heightPaletter.Length ? heightPaletter[y] : (byte)0;
						}
					}
				}
				var chunk = new ChunkMesh(coord, _world, _voxelMap);
				_map.Add(coord, chunk);
			}
			return new ValueTask<ChunkMesh>(_map[coord]);
		}

		public ValueTask Set(Chunk16x16x16 chunk)
		{
			throw new NotImplementedException();
		}
	}
}
