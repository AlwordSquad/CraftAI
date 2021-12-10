using Moq;
using SEGate.Logic.Abstractions;
using Xunit;

namespace SEGate.Logic.Tests.EventHandler
{
	public class ChunkDataPacketHandlerTests : IClassFixture<AgentFixture>
	{
		private readonly AgentFixture _agentFixture;
		private readonly Mock<IAgentConnection> _agentConnection = new Mock<IAgentConnection>();
		public ChunkDataPacketHandlerTests(AgentFixture agentFixture)
		{
			_agentFixture = agentFixture;
		}

		//[Fact]
		//public void TestChunkReader()
		//{
		//	// arrange
		//	var reader = new ChunkDataPacketHandler();
		//	var chunkDataPacket = new ChunkDataPacket()
		//	{
		//		ChunkX = 5,
		//		ChunkZ = -5,
		//		Data = _agentFixture.ReadBytes("chunkData5-5.bin"),
		//		PrimaryBitMask = new[] { 15L }
		//	};
		//	// act
		//	reader.Consume(_agentConnection.Object, chunkDataPacket);
		//	// assert
		//}
	}
}
