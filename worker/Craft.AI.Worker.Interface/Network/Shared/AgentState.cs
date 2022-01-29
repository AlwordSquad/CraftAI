using MessagePack;

namespace Craft.AI.Worker.Interface.Network.Shared
{
	[MessagePackObject]
	public class AgentState
	{
		[Key(1)] public int Id { get; set; }
		[Key(2)] public float X { get; set; }
		[Key(3)] public float Y { get; set; }
		[Key(4)] public float Z { get; set; }
	}
}
