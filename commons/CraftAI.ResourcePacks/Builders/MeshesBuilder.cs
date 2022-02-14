using CraftAI.ResourcePacks.Models;

namespace CraftAI.ResourcePacks.Builders
{
	public class MeshesBuilder
	{
		public static BlockMeshPalette PaletteFrom(ResourcePackJson resourcePackJson)
		{
			var parents = new Dictionary<string, ParentList<BlockJson>>();

			foreach (var block in resourcePackJson.Blocks)
			{
				if (parents.ContainsKey(block.Key)) continue;

				parents[block.Key] = new ParentList<BlockJson>(block.Value);

				var node = parents[block.Key];
				while (node.Value.Parent is not null)
				{
					var parentNode = parents.ContainsKey(node.Value.Parent)
						? parents[node.Value.Parent]
						: From(resourcePackJson, node.Value);
					node.Parent = parentNode;
					node = parentNode;
				}
			}

			throw new NotImplementedException();
		}

		private static ParentList<BlockJson> From(ResourcePackJson resourcePackJson, BlockJson blockJson)
		{
			if (blockJson.Parent is null) throw new ArgumentNullException(nameof(blockJson.Parent));
			var key = blockJson.Parent;
			return new ParentList<BlockJson>(resourcePackJson.Blocks[key]);
		}
	}
}
