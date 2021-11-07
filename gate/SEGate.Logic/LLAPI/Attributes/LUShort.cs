using System;
using System.IO;
using System.Linq;

namespace CraftAI.Gate.Logic.LLAPI.Attributes
{
	/// <summary>
	/// Minecraft packet for <see cref="double"/>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public class LDouble : LType
	{
		public override dynamic Read(Stream stream)
		{
			var buffer = new byte[8];
			stream.Read(buffer);
			buffer = buffer.Reverse()
				.ToArray();
			var result = (double)BitConverter.ToDouble(buffer, 0);
			return result;
		}

		public override void Write(dynamic value, Stream stream)
		{
			var val = (double)value;
			var bytes = BitConverter.GetBytes(val)
				.Reverse()
				.ToArray();
			stream.Write(bytes);
		}
	}
}
