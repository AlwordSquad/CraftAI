using MessagePack;

namespace Craft.AI.Worker.Interface.Network.Clientbound
{
	[MessagePackObject]
	public class CreateSandboxResponse
	{
		[Key(1)] public string UUID { get; set; }

		[Key(2)] public string Name { get; set; }
	}
}
