using SEGate.Logic.LLAPI.Attributes;

namespace SEGate.Logic.LLAPI.Login.Clientbound
{
	public record SetCompression : IPacketData
	{
		/// <summary>Maximum size of a packet before it is compressed</summary>
		[LVarint] public int Threshold { get; set; }
	}
}
