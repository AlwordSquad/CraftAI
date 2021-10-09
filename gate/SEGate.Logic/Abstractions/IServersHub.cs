using SEGate.Logic.Connection;

namespace SEGate.Logic.Abstractions
{
	public interface IServersHub
	{
		ServerAgents EnsureServer(string host);

	}
}
