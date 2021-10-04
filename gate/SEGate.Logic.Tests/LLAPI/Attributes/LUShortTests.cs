using SEGate.Logic.LLAPI.Attributes;
using System.IO;
using Xunit;

namespace SEGate.Logic.Tests.LLAPI.Attributes
{
	public class LUShortTests
	{
		private readonly LUShort _attribute = new();
		[Theory]
		[InlineData(12)]
		[InlineData(20)]
		public void UseLUShort(ushort expected)
		{
			// arrange
			using MemoryStream memoryStream = new();
			// act 
			_attribute.Write(expected, memoryStream);
			Assert.Equal(2, memoryStream.Length);
			memoryStream.Seek(0, SeekOrigin.Begin);
			var value = _attribute.Read(memoryStream);
			var actual = (ushort)value;
			// assert
			Assert.Equal(actual, value);
		}
	}
}
