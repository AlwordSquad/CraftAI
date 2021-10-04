using SEGate.Logic.LLAPI.Abstractions;
using SEGate.Logic.LLAPI.Attributes;
using System.IO;
using System.Net.Sockets;

namespace SEGate.Logic.LLAPI
{
	public class PacketSender : IPacketSender
	{
		private readonly IServerboundPacketMapping _packetMapping;
		private readonly bool _compression;
		private readonly int _threshold;
		public PacketSender(IServerboundPacketMapping packetMapping, bool compression = false, int threshold = 0)
		{
			_packetMapping = packetMapping;
			_compression = compression;
			_threshold = threshold;
		}

		public void SendPacket(IPacketData packet, NetworkStream stream)
		{
			using MemoryStream packetIdAndDataStream = new MemoryStream();
			var packageId = _packetMapping.PacketIdFromType(packet.GetType());
			LVarint.Convertor.Write(packageId, packetIdAndDataStream);
			PacketDataBuilder.Instance.Write(packet, packetIdAndDataStream);
			int dataLength = (int)packetIdAndDataStream.Length;
			if (packetIdAndDataStream.Length > _threshold)
			{
				var compressed = Ionic.Zlib.ZlibStream.CompressBuffer(packetIdAndDataStream.ToArray());
				packetIdAndDataStream.SetLength(0);
				packetIdAndDataStream.Write(compressed);
			}
			else
			{
				dataLength = 0;
			}
			using var dataLenghtStream = new MemoryStream();
			LVarint.Convertor.Write(dataLength, dataLenghtStream);
			int packetLength = (int)dataLenghtStream.Length + (int)packetIdAndDataStream.Length;

			// network
			using var buffer = new MemoryStream();
			LVarint.Convertor.Write(packetLength, buffer);
			LVarint.Convertor.Write(dataLength, buffer);
			buffer.Write(packetIdAndDataStream.ToArray());
			stream.Write(buffer.ToArray());
		}
	}
}
