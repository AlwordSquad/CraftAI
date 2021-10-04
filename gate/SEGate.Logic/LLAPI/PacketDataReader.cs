using SEGate.Logic.LLAPI;
using SEGate.Logic.LLAPI.Attributes;
using System.IO;
using System.Reflection;

namespace SEGate.Logic
{
	public class PacketDataReader : PacketDataProcessor
	{
		public static readonly PacketDataReader Instance = new PacketDataReader();
		public void Read(IPacketData packet, Stream stream) => Deconstruct(packet, stream);
		protected override void Handle(PropertyInfo prop, IPacketData packet, Stream stream, LType type)
		{
			var value = type.Read(stream);
			prop.SetValue(packet, value);
		}
	}
}
