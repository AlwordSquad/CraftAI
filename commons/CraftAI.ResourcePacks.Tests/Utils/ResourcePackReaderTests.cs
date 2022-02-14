using CraftAI.ResourcePacks.Builders;
using CraftAI.ResourcePacks.Utils;
using Xunit;

namespace CraftAI.ResourcePacks.Tests.Utils
{
	public class ResourcePackReaderTests
	{
		[Fact]
		public void ReadDefaultResourcePack()
		{
			var jsonModel = ResourcePackReader.FromDefaults();
			var palette = MeshesBuilder.PaletteFrom(jsonModel);
		}
	}
}
