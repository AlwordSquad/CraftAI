using CraftAI.Gate.Logic.Abstractions;
using CraftAI.Gate.Logic.LLAPI.Abstractions;

namespace CraftAI.Gate.Logic.Connection
{
	public sealed partial class AgentConnection : IAgentConnection
	{
		public void Send(IPacketData packetData)
		{
			packetSender.SendPacket(packetData, _stream);
		}
	}
}
