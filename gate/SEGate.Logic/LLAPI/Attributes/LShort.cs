using System;
using System.IO;
using System.Linq;

namespace SEGate.Logic.LLAPI.Attributes
{
	/// <summary>
	/// Minecraft packet for <see cref="short"/>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public class LShort : LType
	{
		public static readonly LShort Convertor = new();
		public override dynamic Read(Stream stream)
		{
			var buffer = new byte[2];
			stream.Read(buffer);
			buffer = buffer.Reverse()
				.ToArray();
			var result = (short)BitConverter.ToInt16(buffer, 0);
			return result;
		}

		public override void Write(dynamic value, Stream stream)
		{
			var val = (short)value;
			var bytes = BitConverter.GetBytes(val)
				.Reverse()
				.ToArray();
			stream.Write(bytes);
		}
	}
}
