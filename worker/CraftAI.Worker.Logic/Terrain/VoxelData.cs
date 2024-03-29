﻿using Craft.AI.Worker.Interface.Network.Shared;
using System.Numerics;

namespace CraftAI.Worker.Logic.Terrain
{
	public static class VoxelData
	{
		public static readonly int ChunkWidth = 16;
		public static readonly int ChunkHeight = 16;
		public static readonly int WorldSizeInChunks = 100;
		public static int WorldSizeInVoxels
		{
			get { return WorldSizeInChunks * ChunkWidth; }
		}

		public static readonly int ViewDistanceInChunks = 5;
		public static readonly int TextureAtlasSizeInBlocks = 64;
		public static float NormalizedBlockTextureSize
		{
			get { return 1f / TextureAtlasSizeInBlocks; }
		}

		public static readonly Int3[] voxelVerts = new Int3[8]
		{
			new Int3(0, 0, 0),
			new Int3(1, 0, 0),
			new Int3(1, 1, 0),
			new Int3(0, 1, 0),
			new Int3(0, 0, 1),
			new Int3(1, 0, 1),
			new Int3(1, 1, 1),
			new Int3(0, 1, 1),
		};

		public static readonly Int3[] faceChecks = new Int3[6]
		{
			new Int3(0, 0, -1),
			new Int3(0, 0, 1),
			new Int3(0, 1, 0),
			new Int3(0, -1, 0),
			new Int3(-1, 0, 0),
			new Int3(1, 0, 0)
		};

		public static readonly int[,] voxelTris = new int[6, 4]
		{
			// Back, Front, Top, Bottom, Left, Right
			// 0 1 2 2 1 3
			{0, 3, 1, 2}, // Back Face
			{5, 6, 4, 7}, // Front Face
			{3, 7, 2, 6}, // Top Face
			{1, 5, 0, 4}, // Bottom Face
			{4, 7, 0, 3}, // Left Face
			{1, 2, 5, 6} // Right Face
		};

		public static readonly Vector2[] voxelUvs = new Vector2[4]
		{
			new Vector2 (0.0f, 0.0f),
			new Vector2 (0.0f, 1.0f),
			new Vector2 (1.0f, 0.0f),
			new Vector2 (1.0f, 1.0f)
		};
	}
}
