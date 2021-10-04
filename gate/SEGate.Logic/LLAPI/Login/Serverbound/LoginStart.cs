using SEGate.Logic.LLAPI.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SEGate.Logic.LLAPI.Login.Serverbound
{
	public record LoginStart : IPacketData
	{
		/// <summary>Player's Username.</summary>
		[LString] [MaxLength(16)] public string Name { get; set; }
		public static LoginStart Nick(string nickName) => new LoginStart()
		{
			Name = nickName
		};
	}
}
