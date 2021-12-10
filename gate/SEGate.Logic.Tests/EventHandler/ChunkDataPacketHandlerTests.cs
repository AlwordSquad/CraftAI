<<<<<<< HEAD
﻿using Moq;
using SEGate.Logic.Abstractions;
=======
﻿using CraftAI.Gate.Logic.Abstractions;
using Moq;
>>>>>>> af32b0cb5c329dfafa204ac3eddb57b51d274ebc
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

<<<<<<< HEAD
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
=======
		[Fact]
		public void TestChunkReader()
		{
			// arrange
			//// var reader = new ChunkDataPacketHandler();
			//var chunkDataPacket = new ChunkDataPacket()
			//{
			//	ChunkX = 5,
			//	ChunkZ = -5,
			//	Data = _agentFixture.ReadBytes("chunkData5-5.bin"),
			//	PrimaryBitMask = new[] { 15L }
			//};
			//// act
			//reader.Consume(_agentConnection.Object, chunkDataPacket);
			//// assert
		}
>>>>>>> af32b0cb5c329dfafa204ac3eddb57b51d274ebc
	}
}
