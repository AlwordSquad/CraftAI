using System;
using System.IO;
using System.Linq;

namespace CraftAI.Gate.Logic.LLAPI.Attributes
{
	/// <summary>
	/// Minecraft packet for <see cref="ushort"/>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public class LLong : LType
	{
		public static readonly LLong Convertor = new();
		public override dynamic Read(Stream stream)
		{
			var buffer = new byte[8];
			stream.Read(buffer);
			buffer = buffer.Reverse()
				.ToArray();
			var result = BitConverter.ToInt64(buffer, 0);
			return result;
		}

		public override void Write(dynamic value, Stream stream)
		{
			var val = (long)value;
			var bytes = BitConverter.GetBytes(val)
				.Reverse()
				.ToArray();
			stream.Write(bytes);
		}
	}
}
