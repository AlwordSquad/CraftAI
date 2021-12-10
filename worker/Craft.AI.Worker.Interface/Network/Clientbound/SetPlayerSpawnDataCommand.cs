using MessagePack;

namespace Craft.AI.Worker.Interface.Network.Clientbound
{
	[MessagePackObject]
	public class SetPlayerSpawnDataCommand
	{
		[Key(1)] public int EntityId { get; set; }
		[Key(2)] public string PlayerUUUI { get; set; }
		[Key(3)] public double X { get; set; }
		[Key(4)] public double Y { get; set; }
		[Key(5)] public double Z { get; set; }
		[Key(6)] public byte Yaw { get; set; }
		[Key(7)] public byte Pitch { get; set; }
	}
}
