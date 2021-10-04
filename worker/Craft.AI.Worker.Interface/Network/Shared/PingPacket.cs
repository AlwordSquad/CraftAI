using MessagePack;

namespace Craft.AI.Worker.Interface.Network.Shared
{
	[MessagePackObject]
	public class PingPacket
	{
		[Key(1)]
		public long Timestamp { get; set; }
	}
}
