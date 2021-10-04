using CraftAI.Worker.Logic.Terrain;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.Services
{
	public interface ITerrainService
	{
		ValueTask<Chunk> Get(short x, short y);
	}
}
