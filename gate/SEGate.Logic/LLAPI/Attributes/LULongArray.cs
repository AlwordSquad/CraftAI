using System;
using System.IO;

namespace SEGate.Logic.LLAPI.Attributes
{
	/// <summary>
	/// Minecraft packet for <see cref="ushort"/>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public class LULongArray : LType
	{
		public static readonly LULongArray Convertor = new();
		public override dynamic Read(Stream stream)
		{
			int count = (int)LVarint.Convertor.Read(stream);
			var array = new ulong[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = LULong.Convertor.Read(stream);
			}
			return array;
		}

		public override void Write(dynamic value, Stream stream)
		{
			var val = (ulong[])value;
			LVarint.Convertor.Write(val.Length, stream);
			for (int i = 0; i < val.Length; i++)
			{
				LULong.Convertor.Write(val[i], stream);
			}
		}
	}
}
