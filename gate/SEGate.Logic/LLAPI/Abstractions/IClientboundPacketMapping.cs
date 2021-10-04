using System;

namespace SEGate.Logic.LLAPI.Abstractions
{
	public interface IClientboundPacketMapping
	{
		public Type TypeFromPacketId(int packetId);
	}
}
