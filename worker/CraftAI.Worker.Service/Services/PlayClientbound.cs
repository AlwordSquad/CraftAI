using CraftAI.Gate.Service;
using Grpc.Core;
using System.Threading.Tasks;

namespace CraftAI.Worker.Service.Services
{
	public class PlayClientbound : CraftAIPlayClientbound.CraftAIPlayClientboundBase
	{
		public override Task<Void> ChunkData(Chunk16x16x16 request, ServerCallContext context)
		{
			return base.ChunkData(request, context);
		}
	}
}
