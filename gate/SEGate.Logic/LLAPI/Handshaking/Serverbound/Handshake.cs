using SEGate.Logic.LLAPI.Attributes;
using SEGate.Logic.LLAPI.Enums;

namespace SEGate.Logic.LLAPI.Handshaking
{
	public record Handshake : IPacketData
	{
		[LVarint] public int ProtocolVersion { get; set; } // https://wiki.vg/Protocol#Handshake
		[LString] public string ServerAddress { get; set; }
		[LUShort] public ushort ServerPort { get; set; }
		[LVarint] public NextState NextState { get; set; }

		public static Handshake Latest(string address, ushort port, NextState nextState = NextState.Login) => new()
		{
			ProtocolVersion = 756,
			ServerAddress = address,
			ServerPort = port,
			NextState = nextState
		};
	}
}
