using SEGate.Logic.LLAPI;
using SEGate.Logic.LLAPI.Attributes;
using System.IO;
using System.Reflection;

namespace SEGate.Logic
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
