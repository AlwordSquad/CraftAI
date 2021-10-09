using Craft.AI.Worker.Interface.Abstractions;
using Craft.AI.Worker.Interface.Network.Serverbound;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.EventHandlers
{
	class CreateAgentEventHandler : BaseEventHandler<CreateAgentRequest>
	{
		protected override Task Handle(ISender sender, CreateAgentRequest value)
		{
			throw new System.NotImplementedException();
		}
	}
}
