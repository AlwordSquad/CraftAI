using Craft.AI.Worker.Interface.Network.Shared;
using System;

namespace CraftAI.Worker.Logic.Terrain
{
	public class ChunkCoord
	{
		public int X;
		public int Z;

		public int WorldX => X * VoxelData.ChunkWidth;
		public int WorldZ => Z * VoxelData.ChunkWidth;

		public ChunkCoord()
		{
			X = 0;
			Z = 0;
		}

		public ChunkCoord(int _x, int _z)
		{
			X = _x;
			Z = _z;
		}

		public ChunkCoord(Int3 pos)
		{
			int xCheck = pos.X;
			int zCheck = pos.Z;
			X = xCheck / VoxelData.ChunkWidth;
			Z = zCheck / VoxelData.ChunkWidth;
		}

		public bool Equals(ChunkCoord other)
		{
			if (other == null)
				return false;
			else if (other.X == X && other.Z == Z)
				return true;
			else
				return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(X, Z);
		}

		public static implicit operator ChunkPosition(ChunkCoord d) => new()
		{
			X = (short)d.X,
			Z = (short)d.Z
		};
	}
}
