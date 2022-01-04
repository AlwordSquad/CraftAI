using CraftAI.Gate.Service;
using System.Threading.Tasks;

namespace CraftAI.Gate.Contract
{
	public interface IGateWorker
	{
		public Task SetChunkData(Chunk16x16x16 chunk);
		public Task SpawnPlayer(SpawnPlayer player);
	}
}
