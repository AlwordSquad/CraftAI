using Craft.AI.Worker.Interface;
using CraftAI.Worker.Logic.Services.SandboxState;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.Commands
{
	public class SendStateToClientCommand : IRequest<Unit>
	{
		public IWeb Sender { get; set; } = null!;
		public ISandboxSate State { get; set; } = null!;
	}
	public class SendStateToClient : IRequestHandler<SendStateToClientCommand, Unit>
	{
		public Task<Unit> Handle(SendStateToClientCommand request, CancellationToken cancellationToken)
		{
			return Task.FromResult(Unit.Value);
		}
	}
}
