using CraftAI.ResourcePacks.Utils;
using Xunit;

namespace CraftAI.ResourcePacks.Tests.Utils
{
	public class ResourcePackReaderTests
	{
		[Fact]
		public void ReadDefaultResourcePack()
		{
			var stream = ResourcePackReader.FromDefaults();
		}
	}
}
