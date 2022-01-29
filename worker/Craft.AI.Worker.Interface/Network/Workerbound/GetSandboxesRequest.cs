using MessagePack;

namespace Craft.AI.Worker.Interface.Network.Workerbound
{
	[MessagePackObject]
	public class GetSandboxesRequest
	{
		[Key(0)] byte Method { get; set; }
		public static GetSandboxesRequest All = new GetSandboxesRequest();
	}
}
