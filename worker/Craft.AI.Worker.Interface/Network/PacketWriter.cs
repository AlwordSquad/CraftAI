using MessagePack;
using System;
using System.Collections.Generic;

namespace Craft.AI.Worker.Interface
{
	public class PacketWriter
	{
		private readonly IReadOnlyDictionary<Type, byte> _mapping;
		private byte _packetMetaSize = sizeof(int) + 1;

		public PacketWriter(IReadOnlyDictionary<Type, byte> mapping)
		{
			_mapping = mapping;
		}

		public byte[] WriteData<T>(T message)
		{
			var key = _mapping[message.GetType()];
			var streamArray = MessagePackSerializer.Serialize<T>(message);
			var bufferSize = streamArray.Length;
			var buffer = new byte[bufferSize + sizeof(int) + sizeof(byte)];
			var length = BitConverter.GetBytes(bufferSize);
			Array.Copy(length, 0, buffer, 0, length.Length);
			buffer[length.Length] = key;
			var packerData = streamArray;
			Array.Copy(packerData, 0, buffer, length.Length + 1, packerData.Length);
			return buffer;
		}
	}
}
