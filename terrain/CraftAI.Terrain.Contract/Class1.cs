using System.Collections.Generic;
using System.Threading.Tasks;

namespace CraftAI.Terrain.Contract
{
	public interface ITerrainService
	{
		public ValueTask Subscribe(string serverIp);
		public ValueTask Unsubscibe(string serverIp);
		public ValueTask<ICollection<string>> Subscriptions();
		public ValueTask<int> GetSize();
		public ValueTask<int> GetSize(string serverIp);
		public ValueTask Clear(string serverIp);
		public ValueTask GetChunk(int x, int y, int z);
	}
}
