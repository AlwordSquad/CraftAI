using CraftAI.Gate.Features.Abstractions;
using Grpc.Core;
using MediatR;
using System.Threading.Tasks;

namespace CraftAI.Gate.Service.Services
{
	public class PlayServerbound : CraftAIPlayServerbound.CraftAIPlayServerboundBase
	{
		private readonly IMediator _mediator;
		public PlayServerbound(IMediator mediator) => _mediator = mediator;
		public override Task<ConnectResponse> Connect(ConnectRequest request, ServerCallContext context)
			=> _mediator.Send(new BaseRequest<ConnectRequest, ConnectResponse>(request));

	}
}
