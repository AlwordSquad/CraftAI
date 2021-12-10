using CraftAI.Gate.Logic.LLAPI.Abstractions;
using CraftAI.Gate.Logic.LLAPI.Attributes;

namespace CraftAI.Gate.Logic.LLAPI.Login.Clientbound
{
	public record SetCompression : IPacketData
	{
		/// <summary>Maximum size of a packet before it is compressed</summary>
		[LVarint] public int Threshold { get; set; }
	}
}
