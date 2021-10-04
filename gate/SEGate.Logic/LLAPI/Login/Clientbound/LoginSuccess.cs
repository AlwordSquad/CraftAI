using SEGate.Logic.LLAPI.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace SEGate.Logic.LLAPI.Login.Clientbound
{
	public record LoginSuccess : IPacketData
	{
		/// <summary>Player's Username.</summary>
		[LUUID] public Guid UUID { get; set; }
		[LString] [MaxLength(16)] public string Username { get; set; }
	}
}
