using System;
using System.IO;
using System.Linq;

namespace CraftAI.Gate.Logic.LLAPI.Attributes
{
	/// <summary>
	/// Minecraft packet for <see cref="ushort"/>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public class LUShort : LType
	{
		public override dynamic Read(Stream stream)
		{
			var buffer = new byte[2];
			stream.Read(buffer);
			buffer = buffer.Reverse()
				.ToArray();
			var result = (ushort)BitConverter.ToInt16(buffer, 0);
			return result;
		}

		public override void Write(dynamic value, Stream stream)
		{
			var val = (ushort)value;
			var bytes = BitConverter.GetBytes(val)
				.Reverse()
				.ToArray();
			stream.Write(bytes);
		}
	}
}
