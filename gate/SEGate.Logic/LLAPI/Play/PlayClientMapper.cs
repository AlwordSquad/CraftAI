using CraftAI.Gate.Logic.LLAPI.Abstractions;
using CraftAI.Gate.Logic.LLAPI.Play.Clientbound;
using CraftAI.Gate.Logic.LLAPI.Play.Shared;
using CraftAI.Gate.Logic.LLAPI.Stub;
using System;
using System.Collections.Generic;

namespace CraftAI.Gate.Logic.LLAPI.Play
{
	public class PlayClientMapper : IClientboundPacketMapping
	{
		private readonly Dictionary<int, Type> _packetType = new()
		{
			{ 0x21, typeof(KeepAlivePacket) },
			// { 0x22, typeof(ChunkDataPacket) },
			{ 0x04, typeof(SpawnPlayerPacket) },
		};
		public Type TypeFromPacketId(int packetId)
		{
			if (_packetType.ContainsKey(packetId)) return _packetType[packetId];

			return typeof(EmptyPacket);
		}
	}
}
