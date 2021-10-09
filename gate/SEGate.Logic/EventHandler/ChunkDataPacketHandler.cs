using CraftAI.Gate.Service;
using SEGate.Interface.Types;
using SEGate.Logic.Abstractions;
using SEGate.Logic.LLAPI.Play.Clientbound;
using SEGate.Logic.Registry;
using System.IO;

namespace SEGate.Logic.EventHandler
{
	public class ChunkDataPacketHandler : IEventHandler<ChunkDataPacket>
	{
		private readonly CraftAIPlayClientbound.CraftAIPlayClientboundClient _client;
		public ChunkDataPacketHandler(CraftAIPlayClientbound.CraftAIPlayClientboundClient client)
		{
			_client = client;
		}

		public async void Consume(IAgentConnection agentConnection, ChunkDataPacket packetData)
		{
			var data = packetData.Data;
			var chunkId = new Int2(packetData.ChunkX, packetData.ChunkZ);
			var chunkColumn = new ChunkColumn();
			using var stream = new MemoryStream(data);
			chunkColumn.Parse(stream, packetData.PrimaryBitMask);
			foreach (var colomn in chunkColumn.Chunks)
			{
				var chunkData = new Chunk16x16x16()
				{
					X = chunkId.X,
					Y = colomn.Key,
					Z = chunkId.Z
				};
				chunkData.BlockType.AddRange(colomn.Value.GetState());
				await _client.ChunkDataAsync(chunkData);
			}
		}
	}
}
