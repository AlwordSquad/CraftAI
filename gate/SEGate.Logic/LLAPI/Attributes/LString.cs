using System;
using System.IO;
using System.Text;

namespace SEGate.Logic.LLAPI.Attributes
{
	/// <summary>
	/// Minecraft packet for <see cref="string"/>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public class LString : LType
	{
		private readonly LVarint _varInt = new();
		public override dynamic Read(Stream stream)
		{
			int length = (int)_varInt.Read(stream);
			var buffer = new byte[length];
			stream.Read(buffer);
			var result = Encoding.UTF8.GetString(buffer);
			return result;
		}

		public override void Write(dynamic value, Stream stream)
		{
			var val = (string)value;
			var bytes = Encoding.UTF8.GetBytes(val);
			var length = bytes.Length;
			_varInt.Write(length, stream);
			stream.Write(bytes);
		}
	}
}
