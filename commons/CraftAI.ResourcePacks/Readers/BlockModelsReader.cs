using CraftAI.ResourcePacks.Models;
using System.Text.Json;

namespace CraftAI.ResourcePacks.Readers
{
	public class BlockModelsReader : IResourceReader
	{
		private static readonly string pattern = "assets/minecraft/models/block/";
		private static readonly JsonSerializerOptions options = new JsonSerializerOptions()
		{
			PropertyNameCaseInsensitive = true,
		};

		public bool IsMatch(string path)
			=> path.Length > pattern.Length && path.StartsWith(@"assets/minecraft/models/block/");

		public void Read(string name, Stream stream, in ResourcePackJson resourcePack)
		{
			var blockObject = JsonSerializer.Deserialize<BlockJson>(stream, options);
			if (blockObject is not null) resourcePack.Blocks[name] = blockObject;
		}
	}
}
