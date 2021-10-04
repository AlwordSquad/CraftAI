using System;
using System.IO;

namespace SEGate.Logic.LLAPI.Attributes
{
	/// <summary>
	/// Minecraft packet for <see cref="int"/>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public sealed class LVarintArray : LType
	{
		public override dynamic Read(Stream stream)
		{
			int count = (int)LVarint.Convertor.Read(stream);
			var array = new int[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = LVarint.Convertor.Read(stream);
			}
			return array;
		}

		public override void Write(dynamic value, Stream stream)
		{
			var val = (int[])value;
			LVarint.Convertor.Write(val.Length, stream);
			for (int i = 0; i < val.Length; i++)
			{
				LVarint.Convertor.Write(val[i], stream);
			}
		}
	}
}
