using System.Net.Sockets;

namespace CraftAI.Gate.Logic.LLAPI.Abstractions
{
	public interface IPacketReader
	{
		IPacketData ReadPacket(NetworkStream stream);
	}
}
