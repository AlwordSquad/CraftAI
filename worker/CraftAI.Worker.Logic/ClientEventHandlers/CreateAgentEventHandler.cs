using Craft.AI.Worker.Interface;
using Craft.AI.Worker.Interface.Network.Serverbound;
using CraftAI.Worker.Logic.Abstractions;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.EventHandlers
{
	public class CreateAgentEventHandler : BaseWebEventHandler<CreateAgentRequest>
	{
		protected override Task Handle(IWeb sender, CreateAgentRequest value)
		{
			throw new System.NotImplementedException();
		}
	}
}
