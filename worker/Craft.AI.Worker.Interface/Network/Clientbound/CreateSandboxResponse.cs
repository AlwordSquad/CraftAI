using MessagePack;

namespace Craft.AI.Worker.Interface.Network.Clientbound
{
	[MessagePackObject]
	public class CreateSandboxResponse
	{
		[Key(1)] public SandboxItem[] SandboxItems { get; set; }
	}

	[MessagePackObject]
	public class SandboxItem
	{
		[Key(1)] public string Id { get; set; } = string.Empty;
		[Key(2)] public string Name { get; set; } = string.Empty;
		[Key(3)] public string Description { get; set; } = string.Empty;
		[Key(4)] public string Address { get; set; } = string.Empty;
	}
}
