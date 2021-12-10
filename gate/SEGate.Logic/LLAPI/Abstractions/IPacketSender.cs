using System.Net.Sockets;

namespace CraftAI.Gate.Logic.LLAPI.Abstractions
{
	public interface IPacketSender
	{
		void SendPacket(IPacketData packet, NetworkStream stream);
	}
}
