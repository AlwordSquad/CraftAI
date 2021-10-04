using SEGate.Logic.LLAPI.Abstractions;
using SEGate.Logic.LLAPI.Login.Clientbound;
using System;
using System.Collections.Generic;

namespace SEGate.Logic.LLAPI.Login
{
	public class LoginClientboundMapping : IClientboundPacketMapping
	{
		public Type TypeFromPacketId(int packetId) => packetType[packetId];

		private readonly Dictionary<int, Type> packetType = new()
		{
			{ 0x02, typeof(LoginSuccess) },
			{ 0x03, typeof(SetCompression) },
		};
	}
}
