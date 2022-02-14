using CraftAI.ResourcePacks.Models;
using System.Text.Json;

namespace CraftAI.ResourcePacks.Readers
{
	public class BlockModelsReader : IResourceReader
	{
		private static readonly string pattern = "assets/minecraft/models/block/";
		private static readonly JsonSerializerOptions options = new()
		{
			PropertyNameCaseInsensitive = true,
		};

		public bool IsMatch(string path)
			=> path.Length > pattern.Length && path.StartsWith(@"assets/minecraft/models/block/");

		public void Read(string name, Stream stream, in ResourcePackJson resourcePack)
		{
			var blockName = $"minecraft:block/{name.Split('.')[0]}";
			var blockObject = JsonSerializer.Deserialize<BlockJson>(stream, options);
			if (blockObject is not null)
			{
				if (blockObject.Parent is not null && !blockObject.Parent.StartsWith("minecraft:"))
				{
					blockObject.Parent = $"minecraft:{blockObject.Parent}";
				}
				blockObject.Name = blockName;
				resourcePack.Blocks[blockName] = blockObject;
			}
		}
	}
}
