using System;
using System.IO;

namespace CraftAI.Gate.Logic.LLAPI.Attributes
{
	/// <summary>
	/// Minecraft packet for <see cref="ushort"/>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public class LLongArray : LType
	{
		public static readonly LLongArray Convertor = new();
		public override dynamic Read(Stream stream)
		{
			int count = (int)LVarint.Convertor.Read(stream);
			var array = new long[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = LLong.Convertor.Read(stream);
			}
			return array;
		}

		public override void Write(dynamic value, Stream stream)
		{
			var val = (long[])value;
			LVarint.Convertor.Write(val.Length, stream);
			for (int i = 0; i < val.Length; i++)
			{
				LLong.Convertor.Write(val[i], stream);
			}
		}
	}
}
