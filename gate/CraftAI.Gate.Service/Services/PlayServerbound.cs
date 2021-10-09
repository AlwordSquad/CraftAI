using Grpc.Core;
using System.Threading.Tasks;

namespace CraftAI.Gate.Service.Services
{
	public class PlayServerbound : CraftAIPlayServerbound.CraftAIPlayServerboundBase
	{
		public override Task<Void> Connect(ConnectRequest request, ServerCallContext context)
		{
			return base.Connect(request, context);
		}
	}
}
