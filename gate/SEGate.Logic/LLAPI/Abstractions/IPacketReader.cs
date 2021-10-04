using System.Net.Sockets;

namespace SEGate.Logic.LLAPI.Abstractions
{
	public interface IPacketReader
	{
		IPacketData ReadPacket(NetworkStream stream);
	}
}
