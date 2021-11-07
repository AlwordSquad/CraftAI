using System.Collections.Generic;
using System.IO;

namespace CraftAI.Gate.Logic.Registry
{
	public class ChunkColumn
	{
		public const int SizeX = 16;
		public const int SizeY = 256;
		public const int SizeZ = 16;
		private readonly Dictionary<int, ChunkSection> _chunks = new Dictionary<int, ChunkSection>(SizeY / ChunkSection.SizeY);
		public IReadOnlyDictionary<int, ChunkSection> Chunks { get => _chunks; }
		public ChunkSection this[int y]
		{
			get
			{
				if (Chunks.ContainsKey(y))
				{
					return Chunks[y];
				}
				else
				{
					return null;
				}
			}
		}

		public void Parse(Stream data, long[] primaryBitMask)
		{
			for (int sectionY = 0; sectionY < SizeY / ChunkSection.SizeY; sectionY++)
			{
				if ((primaryBitMask[0] & 1 << sectionY) != 0)
				{
					var chunkSection = new ChunkSection();
					chunkSection.Parse(data);
					_chunks.Add(sectionY, chunkSection);
				}
			}
		}
	}
}
