using MessagePack;

namespace Craft.AI.Worker.Interface.Network.Serverbound
{
	[MessagePackObject]
	public class CreateAgentRequest
	{
		[Key(1)] public string Nickname { get; set; }
		[Key(2)] public string Host { get; set; }
	}
}
