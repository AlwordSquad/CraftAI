using System;
using System.IO;
using System.Linq;

namespace SEGate.Logic.LLAPI.Attributes
{
	/// <summary>
	/// Minecraft packet for <see cref="Guid"/>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public class LUUID : LType
	{
		public override dynamic Read(Stream stream)
		{
			var buffer = new byte[16];
			stream.Read(buffer);
			buffer = buffer.Reverse().ToArray();
			var result = new Guid(buffer);
			return result;
		}

		public override void Write(dynamic value, Stream stream)
		{
			var val = (Guid)value;
			byte[] result = val.ToByteArray().Reverse().ToArray();
			stream.Write(result);
		}
	}
}
