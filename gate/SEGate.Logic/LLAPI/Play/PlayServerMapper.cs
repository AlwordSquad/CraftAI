
using SEGate.Logic.LLAPI.Abstractions;
using SEGate.Logic.LLAPI.Play.Shared;
using System;
using System.Collections.Generic;

namespace SEGate.Logic.LLAPI.Play
{
	public class PlayServerMapper : IServerboundPacketMapping
	{
		private readonly Dictionary<Type, int> _packetType = new()
		{
			{ typeof(KeepAlivePacket), 0x0F }
		};

		public int PacketIdFromType(Type packet)
		{
			if (_packetType.ContainsKey(packet)) return _packetType[packet];
			throw new NotImplementedException($"Can send this packet type of {packet}");
		}
	}
}
