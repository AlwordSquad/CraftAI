using CraftAI.Gate.Service;
using System.Threading.Tasks;

namespace CraftAI.Gate.Contract
{
	public interface IGate
	{
		/// <summary>
		/// Create agent using server URL and password
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public Task<ConnectResponse> Connect(ConnectRequest request);
	}
}
