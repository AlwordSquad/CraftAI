using CraftAI.Gate.Logic.Abstractions;
using CraftAI.Gate.Logic.LLAPI.Play.Shared;

namespace CraftAI.Gate.Logic.EventHandler
{
	public class KeepAliveEventHandler : IEventHandler<KeepAlivePacket>
	{
		public void Consume(IAgentConnection agentConnection, KeepAlivePacket packetData)
		{
			agentConnection.Send(packetData);
		}
	}
}
