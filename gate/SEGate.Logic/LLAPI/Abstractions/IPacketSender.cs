using System.Net.Sockets;

namespace SEGate.Logic.LLAPI.Abstractions
{
	public interface IPacketSender
	{
		void SendPacket(IPacketData packet, NetworkStream stream);
	}
}
