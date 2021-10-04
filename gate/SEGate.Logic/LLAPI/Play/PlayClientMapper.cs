using SEGate.Logic.LLAPI.Abstractions;
using SEGate.Logic.LLAPI.Play.Clientbound;
using SEGate.Logic.LLAPI.Play.Shared;
using SEGate.Logic.LLAPI.Stub;
using System;
using System.Collections.Generic;

namespace SEGate.Logic.LLAPI.Play
{
	public class PlayClientMapper : IClientboundPacketMapping
	{
		private readonly Dictionary<int, Type> _packetType = new()
		{
			{ 0x21, typeof(KeepAlivePacket) },
			{ 0x22, typeof(ChunkDataPacket) },
		};
		public Type TypeFromPacketId(int packetId)
		{
			if (_packetType.ContainsKey(packetId)) return _packetType[packetId];

			return typeof(EmptyPacket);
		}
	}
}
