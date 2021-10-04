using SEGate.Logic.LLAPI;
using SEGate.Logic.LLAPI.Handshaking;
using System.IO;
using Xunit;

namespace SEGate.Logic.Tests.LLAPI
{
	public class MessageBuilderTests
	{
		[Fact]
		public void WriteHandshake()
		{
			// arrange
			using MemoryStream stream = new();
			IPacketData packet = Handshake.Latest("127.0.0.1", 25565);
			// act
			PacketDataBuilder.Instance.Write(packet, stream);
			stream.Seek(0, SeekOrigin.Begin);
			// assert
			var handshake = new Handshake();
			PacketDataReader.Instance.Read(handshake, stream);

			Assert.Equal(packet, handshake);
		}
	}
}
