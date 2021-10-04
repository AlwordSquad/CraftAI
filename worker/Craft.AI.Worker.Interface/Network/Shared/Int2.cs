using MessagePack;

namespace Craft.AI.Worker.Interface.Network.Shared
{
	[MessagePackObject]
	public struct Int2
	{
		[Key(1)] public int X { get; set; }
		[Key(2)] public int Z { get; set; }

		public Int2(int x, int z)
		{
			X = x;
			Z = z;
		}

		public static Int2 operator +(Int2 a, Int2 b)
		{
			return new Int2(a.X + b.X, a.Z + b.Z);
		}
	}
}
