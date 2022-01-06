using MessagePack;

namespace Craft.AI.Worker.Interface.Network.Workerbound
{
	[MessagePackObject]
	public class ConnectSandboxRequest
	{
		[Key(1)] public string SandboxId { get; set; }
	}
}
