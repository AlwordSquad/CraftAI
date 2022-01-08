using CraftAI.Gate.Logic.LLAPI.Abstractions;
using CraftAI.Gate.Logic.LLAPI.Attributes;
using System;

namespace CraftAI.Gate.Logic.LLAPI.Play.Clientbound
{
	/// <summary>
	/// https://wiki.vg/Protocol#Spawn_Player
	/// This packet is sent by the server when a player comes into visible range, not when a player joins.
	/// This packet must be sent after the Player Info packet that adds the player data for the client to use when spawning a player. 
	/// If the Player Info for the player spawned by this packet is not present when this packet arrives, 
	/// Notchian clients will not spawn the player entity. The Player Info packet includes skin/cape data.
	/// Servers can, however, safely spawn player entities for players not in visible range. The client appears to handle it correctly.
	/// </summary>
	public class SpawnPlayerPacket : IPacketData
	{
		/// <summary>Player's EID.</summary>
		[LVarint] public int EntityID { get; set; }
		/// <summary>See on link for notes on offline mode and NPCs.</summary>
		[LUUID] public Guid PlayerUUID { get; set; }
		[LDouble] public double X { get; set; }
		[LDouble] public double Y { get; set; }
		[LDouble] public double Z { get; set; }
		[LByte] public byte YAW { get; set; }
		[LByte] public byte Pitch { get; set; }
	}
}
