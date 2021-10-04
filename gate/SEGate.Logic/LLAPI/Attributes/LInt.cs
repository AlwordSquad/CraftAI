using System;
using System.IO;
using System.Linq;

namespace SEGate.Logic.LLAPI.Attributes
{
	/// <summary>
	/// Minecraft packet for <see cref="ushort"/>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public class LInt : LType
	{
		public override dynamic Read(Stream stream)
		{
			var buffer = new byte[4];
			stream.Read(buffer);
			buffer = buffer.Reverse()
				.ToArray();
			var result = BitConverter.ToInt32(buffer, 0);
			return result;
		}

		public override void Write(dynamic value, Stream stream)
		{
			var val = (int)value;
			var bytes = BitConverter.GetBytes(val)
				.Reverse()
				.ToArray();
			stream.Write(bytes);
		}
	}
}
