using CraftAI.Gate.Logic.LLAPI.Abstractions;
using CraftAI.Gate.Logic.LLAPI.Attributes;

// https://wiki.vg/Protocol#Keep_Alive_.28clientbound.29
namespace CraftAI.Gate.Logic.LLAPI.Play.Shared
{

	/// <summary>
	/// The server will frequently send out a keep-alive, each containing a random ID.
	/// he client must respond with the same payload (see serverbound Keep Alive)
	/// If the client does not respond to them for over 30 seconds, the server kicks the client.
	/// Vice versa, if the server does not send any keep-alives for 20 seconds
	/// the client will disconnect and yields a "Timed out" exception.
	/// The Notchian server uses a system-dependent time in milliseconds to generate the keep alive ID value.
	/// </summary>
	public record KeepAlivePacket : IPacketData
	{
		/// <summary>Random ID</summary>
		[LLong] public long KeepAliveID { get; set; }
	}
}
