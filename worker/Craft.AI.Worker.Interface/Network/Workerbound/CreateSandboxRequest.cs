using MessagePack;

namespace Craft.AI.Worker.Interface.Network.Serverbound
{
	[MessagePackObject]
	public class CreateSandboxRequest
	{
		[Key(1)] public string Name { get; set; }
		[Key(2)] public string Address { get; set; }
	}
}
