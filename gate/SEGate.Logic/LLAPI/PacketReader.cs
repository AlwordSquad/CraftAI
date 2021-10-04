using SEGate.Logic.LLAPI.Abstractions;
using SEGate.Logic.LLAPI.Attributes;
using System;
using System.IO;
using System.Net.Sockets;

namespace SEGate.Logic.LLAPI
{
	public class PacketReader : IPacketReader
	{
		private const int maxSize = 256 * 1024 * 1024;
		private readonly IClientboundPacketMapping _packetMapping;
		private readonly bool _compression;
		private readonly int _threshold;
		public PacketReader(IClientboundPacketMapping packetMapping, bool compression = false, int threshold = 0)
		{
			_packetMapping = packetMapping;
			_compression = compression;
			_threshold = threshold;
		}

		public IPacketData ReadPacket(NetworkStream stream)
		{
			// Length of Data Length + compressed length of (Packet ID + Data)
			int packetLength = (int)LVarint.Convertor.Read(stream);
			using MemoryStream memoryStream = new(packetLength);
			while (stream.CanRead && memoryStream.Length < packetLength)
			{
				long needRead = packetLength - memoryStream.Length;
				var bytesToRead = new byte[Math.Min(needRead, stream.Socket.Available)];
				stream.Read(bytesToRead);
				memoryStream.Write(bytesToRead);
			}

			memoryStream.Seek(0, SeekOrigin.Begin);

			if (!_compression) return HandlePacket(memoryStream);

			return HandlePacket(HandleCompression(memoryStream));
		}

		private MemoryStream HandleCompression(MemoryStream stream)
		{
			var dataLength = (int)LVarint.Convertor.Read(stream);
			if (dataLength == 0) return stream;

			var start = stream.Position;
			var array = stream.ToArray();
			var compressedData = array[(int)start..];
			var uncompressed = Ionic.Zlib.ZlibStream.UncompressBuffer(compressedData);
			if (dataLength != uncompressed.Length) throw new InvalidOperationException($"{nameof(dataLength)} must be equal {uncompressed} length");
			var memoryStream = new MemoryStream(uncompressed);
			return memoryStream;
		}

		private IPacketData HandlePacket(MemoryStream memoryStream)
		{
			using (memoryStream)
			{
				int packetId = (int)LVarint.Convertor.Read(memoryStream);
				var type = _packetMapping.TypeFromPacketId(packetId);
				var packetData = (IPacketData)Activator.CreateInstance(type);
				PacketDataReader.Instance.Read(packetData, memoryStream);
				return packetData;
			}
		}
	}
}
