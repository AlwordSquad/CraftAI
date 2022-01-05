using Craft.AI.Worker.Interface;
using Craft.AI.Worker.Interface.Abstractions;
using Craft.AI.Worker.Interface.Network.Shared;
using MessagePack;
using Moq;
using System;
using Xunit;

namespace CraftAI.Workter.Interface.Tests
{
	public class PacketInterop
	{
		[Fact]
		public async void Test1()
		{
			var packet = new PingPacket()
			{
				Timestamp = DateTime.UtcNow.Ticks
			};

			var sender = new Mock<ISender>();
			var eventHub = new Mock<IEventHub>();
			var eventHandelr = new Mock<IEventHandler>();
			eventHub.Setup(e => e.Get(typeof(PingPacket))).Returns(eventHandelr.Object);
			var packetWriter = new PacketWriter(ServerboundMapping.Bytes);
			var bytes = packetWriter.WriteData(packet);

			var reader = new WebsocketReader(sender.Object, ServerboundMapping.Types, eventHub.Object);
			reader.Accept(bytes);
			int length = 0;
			eventHandelr.Verify(e => e.Handle(It.Is<ISender>(e => e == sender.Object), It.Is<byte[]>(w => MessagePackSerializer.Deserialize<PingPacket>(w, out length, System.Threading.CancellationToken.None).Timestamp == packet.Timestamp)));
		}
	}
}
