using Craft.AI.Worker.Interface;
using Craft.AI.Worker.Interface.Network.Serverbound;
using CraftAI.Gate.Contract;
using CraftAI.Gate.Service;
using CraftAI.Worker.Logic.Abstractions;
using CraftAI.Worker.Logic.Services.SandboxState;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.EventHandlers
{
	public class CreateAgentEventHandler : BaseSandboxEventHandler<CreateAgentRequest>
	{
		private readonly IGate _gate;
		public CreateAgentEventHandler(ISandboxHub sandboxHub, IGate gate) : base(sandboxHub)
		{
			_gate = gate;
		}
		protected async override Task Handle(IWeb sender, ISandboxSate sandbox, CreateAgentRequest value)
		{
			var uri = sandbox.URI;
			var hasAgent = sandbox.Agents.ContainsKey(value.Nickname);
			if (hasAgent) return;

			await _gate.Connect(new ConnectRequest()
			{
				Nickname = value.Nickname,
				ServerUri = uri
			});
		}
	}
}
