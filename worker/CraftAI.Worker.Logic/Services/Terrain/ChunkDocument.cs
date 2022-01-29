using MongoDB.Bson;
using System;

namespace CraftAI.Worker.Logic.Storage
{
	public record ChunkDocument
	{
		public ObjectId _id { get; set; }
		public string Positions { get; set; }
		public int[] Data { get; set; } // ссылка на изображение
		public ChunkDocument()
		{
			Positions = string.Empty;
			Data = Array.Empty<int>();
		}

		public ChunkDocument(int x, int y, int z)
		{
			Positions = KeyFrom(x, y, z);
			Data = Array.Empty<int>();
		}

		public static string KeyFrom(int x, int y, int z)
		{
			return $"{x}:{y}:{z}";
		}
	}
}
