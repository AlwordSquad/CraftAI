using Craft.AI.Worker.Interface.Network.Shared;
using CraftAI.Worker.Logic.Utils;
using System.Collections.Generic;

namespace CraftAI.Worker.Logic.Terrain
{
	/// <summary>
	/// Render data for UI
	/// </summary>
	public class ChunkMesh
	{
		public Int3[] Vertices => _vertices.ToArray();
		public int[] Triangles => _triangles.ToArray();
		public Float2[] Uvs => _uvs.ToArray();


		private readonly World _world;
		private readonly List<Int3> _vertices = new();
		private readonly List<int> _triangles = new();
		private readonly List<Float2> _uvs = new();
		private readonly int[,,] _voxelMap = new int[VoxelData.ChunkWidth, VoxelData.ChunkHeight, VoxelData.ChunkWidth];

		public ChunkCoord Coord { get; }
		public bool IsActive { get; set; }
		public bool isVoxelMapPopulated = false;

		private int _vertexIndex = 0;
		public ChunkMesh(ChunkCoord _coord, World world, int[,,]? voxelMap = null)
		{
			Coord = _coord;
			_world = world;
			IsActive = true;
			_world.SetChunk(this);
			if (voxelMap != null)
			{
				_voxelMap = voxelMap;
				CreateMeshData();
			}
		}

		public void CreateMeshData()
		{
			for (int y = 0; y < VoxelData.ChunkHeight; y++)
			{
				for (int x = 0; x < VoxelData.ChunkWidth; x++)
				{
					for (int z = 0; z < VoxelData.ChunkWidth; z++)
					{
						AddVoxelDataToChunk(new Int3(x, y, z));
					}
				}
			}

		}
		public Int3 WorldPosition => new(Coord.WorldX, 0, Coord.WorldZ);
		bool IsVoxelInChunk(int x, int y, int z)
		{
			if (
				x < 0 || x > VoxelData.ChunkWidth - 1 ||
				y < 0 || y > VoxelData.ChunkHeight - 1 ||
				z < 0 || z > VoxelData.ChunkWidth - 1)
				return false;
			else
				return true;
		}

		bool CheckVoxel(Int3 pos)
		{
			if (!IsVoxelInChunk(pos.X, pos.Y, pos.Z)) return _world.CheckForVoxel(pos + WorldPosition);
			return _world._textures.Get(_voxelMap[pos.X, pos.Y, pos.Z]).isSolid;
		}

		public int GetVoxelFromGlobalVector3(Int3 pos)
		{
			int xCheck = pos.X;
			int yCheck = pos.Y;
			int zCheck = pos.Z;
			xCheck -= MathConvertor.FloorToInt(Coord.X);
			zCheck -= MathConvertor.FloorToInt(Coord.Z);
			return _voxelMap[xCheck, yCheck, zCheck];
		}

		void AddVoxelDataToChunk(Int3 pos)
		{
			for (int p = 0; p < 6; p++)
			{
				if (CheckVoxel(pos + VoxelData.faceChecks[p])) continue;
				int blockID = _voxelMap[pos.X, pos.Y, pos.Z];
				if (!_world._textures.Get(blockID).isSolid) continue;
				_vertices.Add(pos + VoxelData.voxelVerts[VoxelData.voxelTris[p, 0]]);
				_vertices.Add(pos + VoxelData.voxelVerts[VoxelData.voxelTris[p, 1]]);
				_vertices.Add(pos + VoxelData.voxelVerts[VoxelData.voxelTris[p, 2]]);
				_vertices.Add(pos + VoxelData.voxelVerts[VoxelData.voxelTris[p, 3]]);
				AddTexture(_world._textures.Get(blockID).GetTextureID((Face)p));
				_triangles.Add(_vertexIndex);
				_triangles.Add(_vertexIndex + 1);
				_triangles.Add(_vertexIndex + 2);
				_triangles.Add(_vertexIndex + 2);
				_triangles.Add(_vertexIndex + 1);
				_triangles.Add(_vertexIndex + 3);
				_vertexIndex += 4;
			}
		}
		void AddTexture(int textureID)
		{
			float y = textureID / VoxelData.TextureAtlasSizeInBlocks;
			float x = textureID - y * VoxelData.TextureAtlasSizeInBlocks;
			x *= VoxelData.NormalizedBlockTextureSize;
			y *= VoxelData.NormalizedBlockTextureSize;
			y = 1f - y - VoxelData.NormalizedBlockTextureSize;
			_uvs.Add(new Float2(x, y));
			_uvs.Add(new Float2(x, y + VoxelData.NormalizedBlockTextureSize));
			_uvs.Add(new Float2(x + VoxelData.NormalizedBlockTextureSize, y));
			_uvs.Add(new Float2(x + VoxelData.NormalizedBlockTextureSize, y + VoxelData.NormalizedBlockTextureSize));
		}
	}
}
