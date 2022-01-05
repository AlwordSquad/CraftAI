using Craft.AI.Worker.Interface;
using Craft.AI.Worker.Interface.Network.Clientbound;
using Craft.AI.Worker.Interface.Network.Serverbound;
using CraftAI.Worker.Logic.Abstractions;
using CraftAI.Worker.Logic.Services.Sandbox;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.ClientEventHandlers
{
	public class CreateSandboxRequestHandler : BaseWebEventHandler<CreateSandboxRequest>
	{
		private readonly ISandboxStore _sandboxService;
		public CreateSandboxRequestHandler(ISandboxStore sandboxService)
		{
			_sandboxService = sandboxService;
		}
		protected async override Task Handle(IWeb sender, CreateSandboxRequest value)
		{
			await _sandboxService.AddSandbox(value);
			var elements = await _sandboxService.GetAll();
			var response = new CreateSandboxResponse()
			{
				SandboxItems = elements
			};
			await sender.SetSandboxList(response);
		}
	}
}
