using Craft.AI.Worker.Interface;
using Craft.AI.Worker.Interface.Network.Clientbound;
using Craft.AI.Worker.Interface.Network.Workerbound;
using CraftAI.Worker.Logic.Abstractions;
using CraftAI.Worker.Logic.Services.Sandbox;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.ClientEventHandlers
{
	internal class RemoveSandboxRequestHandler : BaseWebEventHandler<RemoveSandboxRequest>
	{
		private readonly ISandboxStore _sandboxService;

		public RemoveSandboxRequestHandler(ISandboxStore sandboxService)
		{
			_sandboxService = sandboxService;
		}
		protected override async Task Handle(IWeb sender, RemoveSandboxRequest value)
		{
			await _sandboxService.Remove(value.SandboxId);
			var elements = await _sandboxService.GetAll();
			var response = new CreateSandboxResponse()
			{
				SandboxItems = elements
			};
			await sender.SetSandboxList(response);
		}
	}
}
