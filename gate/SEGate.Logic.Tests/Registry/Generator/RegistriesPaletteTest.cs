using CraftAI.Gate.Logic.Registry.Generator;
using Xunit;

namespace SEGate.Logic.Tests.Registry.Generator
{
	public class RegistriesPaletteTest
	{
		[Fact]
		public void GenerateItemsPalette()
		{
			// arrange
			var pallete = new RegistriesPalette();
			// act
			pallete.GenerateScript();
			// assert
		}
	}
}
