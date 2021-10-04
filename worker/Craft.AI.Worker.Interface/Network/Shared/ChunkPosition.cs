using MessagePack;

namespace Craft.AI.Worker.Interface.Network.Shared
{
	[MessagePackObject]
	public struct ChunkPosition
	{
		[Key(1)] public short X { get; set; }
		[Key(2)] public short Z { get; set; }
	}
}
