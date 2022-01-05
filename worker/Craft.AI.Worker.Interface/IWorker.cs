using Craft.AI.Worker.Interface.Network.Serverbound;
using System.Threading.Tasks;

namespace Craft.AI.Worker.Interface
{
	public interface ISandboxService
	{
		Task Create(CreateSandboxRequest createSandboxRequest);
	}
	public interface IWorker : ISandboxService
	{
		Task CreateAgent(CreateAgentRequest request);
		Task RequestTerrain(TerrainRequest request);
	}
}
