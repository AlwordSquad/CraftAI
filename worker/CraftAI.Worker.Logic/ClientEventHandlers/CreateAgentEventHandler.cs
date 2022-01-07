using Craft.AI.Worker.Interface;
using Craft.AI.Worker.Interface.Network.Serverbound;
using CraftAI.Gate.Contract;
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
		protected override Task Handle(IWeb sender, ISandboxSate sandbox, CreateAgentRequest value)
		{
			throw new System.NotImplementedException();
		}
	}
}
