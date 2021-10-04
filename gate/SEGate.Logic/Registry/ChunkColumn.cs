using System.Collections.Generic;
using System.IO;

namespace SEGate.Logic.Registry
{
	public class ChunkColumn
	{
		public const int SizeX = 16;
		public const int SizeY = 256;
		public const int SizeZ = 16;

		Dictionary<int, ChunkSection> chunkSections;

		public ChunkSection this[int y]
		{
			get
			{
				if (chunkSections.ContainsKey(y))
				{
					return chunkSections[y];
				}
				else
				{
					return null;
				}
			}
		}

		public void Parse(Stream data, long[] primaryBitMask)
		{
			chunkSections = new Dictionary<int, ChunkSection>(SizeY / ChunkSection.SizeY);
			for (int sectionY = 0; sectionY < SizeY / ChunkSection.SizeY; sectionY++)
			{
				if ((primaryBitMask[0] & 1 << sectionY) != 0)
				{
					var chunkSection = new ChunkSection();
					chunkSection.Parse(data);
					chunkSections.Add(sectionY, chunkSection);
				}
			}
		}
	}
}
