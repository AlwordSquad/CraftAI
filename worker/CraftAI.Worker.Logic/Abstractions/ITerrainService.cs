using CraftAI.Worker.Logic.Storage;
using CraftAI.Worker.Logic.Terrain;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.Services
{
	public interface ITerrainService
	{
		ValueTask<ChunkMesh> Get(short x, short y);
		ValueTask Set(ChunkDocument chunk);

	}
}
