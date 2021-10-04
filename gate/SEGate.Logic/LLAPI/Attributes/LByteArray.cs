using System;
using System.IO;

namespace SEGate.Logic.LLAPI.Attributes
{
	/// <summary>
	/// Minecraft packet for <see cref="int"/>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public sealed class LByteArray : LType
	{
		public override dynamic Read(Stream stream)
		{
			int count = (int)LVarint.Convertor.Read(stream);
			var array = new byte[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = LByte.Convertor.Read(stream);
			}
			return array;
		}

		public override void Write(dynamic value, Stream stream)
		{
			var val = (byte[])value;
			LVarint.Convertor.Write(val.Length, stream);
			for (int i = 0; i < val.Length; i++)
			{
				LByte.Convertor.Write(val[i], stream);
			}
		}
	}
}
