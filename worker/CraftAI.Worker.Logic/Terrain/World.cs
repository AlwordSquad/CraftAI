using Craft.AI.Worker.Interface.Network.Shared;
using CraftAI.Worker.Logic.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Reflection;

namespace CraftAI.Worker.Logic.Terrain
{
	public class World
	{
		public readonly BlockType[] Blocktypes;
		private readonly Chunk[,] _chunks = new Chunk[VoxelData.WorldSizeInChunks, VoxelData.WorldSizeInChunks];
		private readonly List<ChunkCoord> _activeChunks = new();
		private readonly List<ChunkCoord> _chunksToCreate = new();

		public World()
		{
			using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CraftAI.Worker.Logic.Resources.BlockTypes.json");
			using var reader = new StreamReader(stream ?? throw new ArgumentNullException());
			var text = reader.ReadToEnd();
			Blocktypes = System.Text.Json.JsonSerializer.Deserialize<BlockType[]>(text) ?? throw new ArgumentNullException();
		}

		public void SetChunk(Chunk chunk)
		{
			_chunks[chunk.Coord.X, chunk.Coord.Z] = chunk;
		}

		public IEnumerator CreateChunks()
		{
			while (_chunksToCreate.Count > 0)
			{
				var chunk = _chunksToCreate[0];
				_chunks[chunk.X, chunk.Z].CreateMeshData();
				_chunksToCreate.RemoveAt(0);
				yield return null;
			}
		}

		public ChunkCoord GetChunkCoordFromVector3(Vector3 pos)
		{
			int x = MathConvertor.FloorToInt(pos.X / VoxelData.ChunkWidth);
			int z = MathConvertor.FloorToInt(pos.Z / VoxelData.ChunkWidth);
			return new ChunkCoord(x, z);
		}

		public void UpdateViewDistance(int playerX, int playerZ)
		{
			ChunkCoord coord = new(playerX, playerZ);
			List<ChunkCoord> previouslyActiveChunks = new(_activeChunks);

			// Loop through all chunks currently within view distance of the player.
			for (int x = coord.X - VoxelData.ViewDistanceInChunks; x < coord.X + VoxelData.ViewDistanceInChunks; x++)
			{
				for (int z = coord.Z - VoxelData.ViewDistanceInChunks; z < coord.Z + VoxelData.ViewDistanceInChunks; z++)
				{
					// If the current chunk is in the world...
					if (IsChunkInWorld(new ChunkCoord(x, z)))
					{
						// Check if it active, if not, activate it.
						if (_chunks[x, z] == null)
						{
							_chunks[x, z] = new Chunk(new ChunkCoord(x, z), this, null);
							_chunksToCreate.Add(new ChunkCoord(x, z));
						}
						else if (!_chunks[x, z].IsActive)
						{
							_chunks[x, z].IsActive = true;
						}
						_activeChunks.Add(new ChunkCoord(x, z));
					}

					// Check through previously active chunks to see if this chunk is there. If it is, remove it from the list.
					for (int i = 0; i < previouslyActiveChunks.Count; i++)
					{
						if (previouslyActiveChunks[i].Equals(new ChunkCoord(x, z)))
							previouslyActiveChunks.RemoveAt(i);
					}
				}
			}

			// Any chunks left in the previousActiveChunks list are no longer in the player's view distance, so loop through and disable them.
			foreach (ChunkCoord c in previouslyActiveChunks)
				_chunks[c.X, c.Z].IsActive = false;

		}

		public bool CheckForVoxel(Int3 pos)
		{
			ChunkCoord thisChunk = new(pos);
			if (!IsChunkInWorld(thisChunk) || pos.Y < 0 || pos.Y > VoxelData.ChunkHeight)
				return false;
			if (_chunks[thisChunk.X, thisChunk.Z] != null && _chunks[thisChunk.X, thisChunk.Z].isVoxelMapPopulated)
				return Blocktypes[_chunks[thisChunk.X, thisChunk.Z].GetVoxelFromGlobalVector3(pos)].isSolid;
			return Blocktypes[0].isSolid;
		}

		public bool IsChunkInWorld(ChunkCoord coord)
			=> coord.X > 0 && coord.X < VoxelData.WorldSizeInChunks - 1 && coord.Z > 0 && coord.Z < VoxelData.WorldSizeInChunks - 1;
	}
}
