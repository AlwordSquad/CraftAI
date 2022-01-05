using Craft.AI.Worker.Interface.Abstractions;
using Craft.AI.Worker.Interface.Network.Serverbound;
using CraftAI.Worker.Logic.Services.Sandbox;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.ClientEventHandlers
{
	public class CreateSandboxRequestHandler : BaseEventHandler<CreateSandboxRequest>
	{
		private readonly ISandboxStore _sandboxService;
		public CreateSandboxRequestHandler(ISandboxStore sandboxService)
		{
			_sandboxService = sandboxService;
		}
		protected override Task Handle(ISender sender, CreateSandboxRequest value)
		{
			return _sandboxService.AddSandbox(value);
		}
	}
}
