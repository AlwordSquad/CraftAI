using System;
using System.IO;

namespace SEGate.Logic.LLAPI.Attributes
{
	/// <summary>
	/// Minecraft packet for <see cref="int"/>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public sealed class LVarint : LType
	{
		public static readonly LVarint Convertor = new();

		// https://wiki.vg/Protocol#VarInt_and_VarLong
		private static readonly int maxLength = 5;
		public override dynamic Read(Stream stream)
		{
			int value = 0;
			int length = 0;
			int bitOffset = 0;
			byte currentByte;
			do
			{
				if (bitOffset == 35) throw new ArgumentException("VarInt is too big");
				currentByte = (byte)stream.ReadByte();
				value |= (currentByte & 0b01111111) << bitOffset;
				bitOffset += 7;
			} while ((currentByte & 0b10000000) != 0 && length < maxLength);

			return value;
		}

		public override void Write(dynamic value, Stream stream)
		{
			int length = 0;
			value = (int)value;
			do
			{
				byte currentByte = (byte)(value & 0b01111111);
				// Note: >>> means that the sign bit is shifted with the rest of the number rather than being left alone
				value >>= 7;
				if (value != 0) currentByte |= 0b10000000;
				stream.WriteByte(currentByte);
				length++;
			} while (value != 0 && length < maxLength);
		}
	}
}
