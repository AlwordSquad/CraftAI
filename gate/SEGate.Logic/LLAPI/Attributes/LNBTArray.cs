using NbtLib;
using System;
using System.IO;

namespace SEGate.Logic.LLAPI.Attributes
{
	/// <summary>
	/// Minecraft packet for <see cref="ushort"/>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public class LNBTArray : LType
	{
		public override dynamic Read(Stream stream)
		{
			int count = (int)LVarint.Convertor.Read(stream);
			var array = new NbtCompoundTag[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = LNBT.Convertor.Read(stream);
			}
			return array;
		}

		public override void Write(dynamic value, Stream stream)
		{
			var val = (NbtCompoundTag[])value;
			LVarint.Convertor.Write(val.Length, stream);
			for (int i = 0; i < val.Length; i++)
			{
				LNBT.Convertor.Write(val[i], stream);
			}
		}
	}
}
