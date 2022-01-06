using Craft.AI.Worker.Interface;
using Craft.AI.Worker.Interface.Network.Workerbound;
using CraftAI.Worker.Logic.Abstractions;
using CraftAI.Worker.Logic.Commands;
using CraftAI.Worker.Logic.Services.SandboxState;
using MediatR;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.ClientEventHandlers
{
	public class ConnectSandboxRequestHandler : BaseWebEventHandler<ConnectSandboxRequest>
	{
		private readonly ISandboxHub _sandboxHub;
		private readonly IMediator _mediator;
		public ConnectSandboxRequestHandler(ISandboxHub sandboxHub, IMediator mediator)
		{
			_sandboxHub = sandboxHub;
			_mediator = mediator;
		}
		protected override async Task Handle(IWeb sender, ConnectSandboxRequest value)
		{
			sender.SandboxId = value.SandboxId;
			var state = _sandboxHub.GetState(value.SandboxId);
			await _mediator.Send(new SendStateToClientCommand()
			{
				Sender = sender,
				State = state,
			});
		}
	}
}
