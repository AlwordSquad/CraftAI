using System;
using System.IO;

namespace CraftAI.Gate.Logic.LLAPI.Attributes
{
	/// <summary>
	/// Minecraft packet for <see cref="ushort"/>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public class LByte : LType
	{
		public static readonly LByte Convertor = new();
		public override dynamic Read(Stream stream)
		{
			return (byte)stream.ReadByte();
		}

		public override void Write(dynamic value, Stream stream)
		{
			stream.WriteByte((byte)value);
		}
	}
}
