using NbtLib;
using System;
using System.IO;

namespace SEGate.Logic.LLAPI.Attributes
{
	class LNBT : LType
	{
		public static readonly LNBT Convertor = new();
		public override dynamic Read(Stream stream)
		{
			var parser = new NbtParser();
			var exists = stream.ReadByte();
			if (exists == 0)
			{
				return new NbtCompoundTag();
			}
			else
			{
				stream.Seek(-1, SeekOrigin.Current);
				return parser.ParseNbtStream(stream);
			}
		}

		public override void Write(dynamic value, Stream stream)
		{
			throw new NotImplementedException();
		}
	}
}
