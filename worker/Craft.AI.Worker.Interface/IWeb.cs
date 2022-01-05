using Craft.AI.Worker.Interface.Network.Clientbound;
using System.Threading.Tasks;

namespace Craft.AI.Worker.Interface
{
	public interface IWeb
	{
		Task SetSandboxList(CreateSandboxResponse response);
	}
}
