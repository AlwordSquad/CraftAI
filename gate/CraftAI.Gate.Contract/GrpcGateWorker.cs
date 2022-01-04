using CraftAI.Gate.Service;
using System.Threading.Tasks;

namespace CraftAI.Gate.Contract
{
	internal class GrpcGateWorker : IGateWorker
	{
		private readonly CraftAIPlayClientbound.CraftAIPlayClientboundClient _playClientboundClient;
		public GrpcGateWorker(CraftAIPlayClientbound.CraftAIPlayClientboundClient playClientboundClient)
		{
			_playClientboundClient = playClientboundClient;
		}
		public async Task SetChunkData(Chunk16x16x16 chunk)
			=> await _playClientboundClient.ChunkDataAsync(chunk);

		public async Task SpawnPlayer(SpawnPlayer player)
			=> await _playClientboundClient.SpawnPlayerAsync(player);
	}
}
