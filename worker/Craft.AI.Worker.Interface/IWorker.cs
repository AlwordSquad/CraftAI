using Craft.AI.Worker.Interface.Network.Serverbound;
using System.Threading.Tasks;

namespace Craft.AI.Worker.Interface
{
	public interface IWorker
	{
		Task Create(CreateSandboxRequest createSandboxRequest);
		Task CreateAgent(CreateAgentRequest request);
		Task RequestTerrain(TerrainRequest request);
		Task CreateSandbox(CreateSandboxRequest request);
	}
}
