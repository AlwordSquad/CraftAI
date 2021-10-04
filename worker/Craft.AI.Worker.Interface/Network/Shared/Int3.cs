using MessagePack;

namespace Craft.AI.Worker.Interface.Network.Shared
{
	[MessagePackObject]
	public struct Int3
	{
		[Key(1)] public int X { get; set; }
		[Key(2)] public int Y { get; set; }
		[Key(3)] public int Z { get; set; }

		public Int3(int x, int y, int z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public static Int3 operator +(Int3 a, Int3 b)
		{
			return new Int3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
		}

		public override bool Equals(object obj)
		{
			return obj is Int3 @int &&
				   X == @int.X &&
				   Y == @int.Y &&
				   Z == @int.Z;
		}

		public override int GetHashCode()
		{
			int hashCode = -307843816;
			hashCode = hashCode * -1521134295 + X.GetHashCode();
			hashCode = hashCode * -1521134295 + Y.GetHashCode();
			hashCode = hashCode * -1521134295 + Z.GetHashCode();
			return hashCode;
		}
	}
}
