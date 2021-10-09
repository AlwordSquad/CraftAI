using CraftAI.Gate.Service;
using CraftAI.Worker.Logic.Terrain;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.Services
{
	public interface ITerrainService
	{
		ValueTask<ChunkMesh> Get(short x, short y);
		ValueTask Set(Chunk16x16x16 chunk);

	}
}
