using CraftAI.Gate.Features.Abstractions;
using CraftAI.Gate.Service;
using Grpc.Core;
using MediatR;
using System.Threading.Tasks;

namespace CraftAI.Worker.Service.Services
{
	public class PlayClientbound : CraftAIPlayClientbound.CraftAIPlayClientboundBase
	{
		private readonly IMediator _mediator;
		public PlayClientbound(IMediator mediator) => _mediator = mediator;

		public override Task<Void> ChunkData(Chunk16x16x16 request, ServerCallContext context)
			=> _mediator.Send(new BaseRequest<Chunk16x16x16, Void>(request));

		public override Task<Void> SpawnPlayer(SpawnPlayer request, ServerCallContext context)
			=> _mediator.Send(new BaseRequest<SpawnPlayer, Void>(request));
	}
}
