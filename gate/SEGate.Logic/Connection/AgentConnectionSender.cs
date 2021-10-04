using SEGate.Logic.Abstractions;
using SEGate.Logic.LLAPI;

namespace SEGate.Logic.Connection
{
	public sealed partial class AgentConnection : IAgentConnection
	{
		public void Send(IPacketData packetData)
		{
			packetSender.SendPacket(packetData, _stream);
		}
	}
}
