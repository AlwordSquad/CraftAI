using SEGate.Interface.Types;
using SEGate.Logic.Abstractions;
using SEGate.Logic.LLAPI.Play.Clientbound;
using SEGate.Logic.Registry;
using System.IO;

namespace SEGate.Logic.EventHandler
{
	public class ChunkDataPacketHandler : IEventHandler<ChunkDataPacket>
	{
		public void Consume(IAgentConnection agentConnection, ChunkDataPacket packetData)
		{
			var data = packetData.Data;
			var chunkId = new Int2(packetData.ChunkX, packetData.ChunkZ);
			var chunkColumn = new ChunkColumn();
			using var stream = new MemoryStream(data);
			chunkColumn.Parse(stream, packetData.PrimaryBitMask);
		}
	}
}
