using CraftAI.Gate.Logic.Connection;

namespace CraftAI.Gate.Logic.Abstractions
{
	public interface IServersHub
	{
		ServerAgents EnsureServer(string host);

	}
}
