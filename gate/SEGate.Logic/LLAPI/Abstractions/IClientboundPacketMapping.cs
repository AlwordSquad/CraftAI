using System;

namespace CraftAI.Gate.Logic.LLAPI.Abstractions
{
	public interface IClientboundPacketMapping
	{
		public Type TypeFromPacketId(int packetId);
	}
}
