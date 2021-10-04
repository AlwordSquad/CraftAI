using MessagePack;

namespace Craft.AI.Worker.Interface.Network.Shared
{
	[MessagePackObject]
	public struct Float2
	{
		[Key(1)] public float X { get; set; }
		[Key(2)] public float Z { get; set; }

		public Float2(float x, float z)
		{
			X = x;
			Z = z;
		}

		public static Float2 operator +(Float2 a, Float2 b)
		{
			return new Float2(a.X + b.X, a.Z + b.Z);
		}
	}
}
