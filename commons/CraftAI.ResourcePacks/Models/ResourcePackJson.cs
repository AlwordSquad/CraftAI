using CraftAI.ResourcePacks.Models;

namespace CraftAI.ResourcePacks
{
	public class ResourcePackJson
	{
		public readonly Dictionary<string, BlockJson> Blocks = new();
		public readonly TexturePack TexturesBlock = new();
	}
}
