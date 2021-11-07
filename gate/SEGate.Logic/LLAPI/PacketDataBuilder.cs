using System.IO;
using System.Reflection;
using CraftAI.Gate.Logic.LLAPI.Abstractions;
using CraftAI.Gate.Logic.LLAPI.Attributes;

namespace CraftAI.Gate.Logic.LLAPI
{
	public class PacketDataBuilder : PacketDataProcessor
	{
		public static readonly PacketDataBuilder Instance = new();
		public void Write(IPacketData packet, Stream stream) => Deconstruct(packet, stream);
		protected override void Handle(PropertyInfo prop, IPacketData packet, Stream stream, LType type)
		{
			var value = prop.GetValue(packet);
			type.Write(value, stream);
		}
	}
}
