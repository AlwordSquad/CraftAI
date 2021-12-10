using CraftAI.Gate.Logic.Connection;
using Xunit;

namespace SEGate.Logic.Tests.Connection
{
	public class ServerAgentsTests : IClassFixture<AgentFixture>
	{
		private readonly AgentFixture _fixture;
		public ServerAgentsTests(AgentFixture agentFixture)
		{
			_fixture = agentFixture;
		}

		[Fact]
		public void ConnectToServer_ShouldPass()
		{
			if (!_fixture.RunOnLocal) return;
			ServerAgents serverAgents = new(_fixture.Host, _fixture.TestCollection);
			serverAgents.CreateAgent(_fixture.Nick);
		}
	}
}
