using Craft.AI.Worker.Interface.Abstractions;
using Craft.AI.Worker.Interface.Network.Shared;
using System;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.EventHandlers
{
	public class PingEventHandler : BaseEventHandler<PingPacket>
	{
		protected override Task Handle(ISender sender, PingPacket value)
		{
			throw new NotImplementedException();
		}
	}
}
