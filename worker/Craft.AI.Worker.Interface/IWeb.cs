using Craft.AI.Worker.Interface.Network.Clientbound;
using System.Threading.Tasks;

namespace Craft.AI.Worker.Interface
{
	public interface IWeb
	{
		string Id { get; }
		string SandboxId { get; set; }
		Task SetSandboxList(CreateSandboxResponse response);
		Task SpawnPlayer(SetPlayerSpawnDataCommand response);
	}
}
