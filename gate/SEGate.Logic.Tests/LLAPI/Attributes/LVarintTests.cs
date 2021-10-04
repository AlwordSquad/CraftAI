using SEGate.Logic.LLAPI.Attributes;
using System.IO;
using Xunit;

namespace SEGate.Logic.Tests.LLAPI.Attributes
{
	public class LVarintTests
	{
		private readonly LVarint attribute = new LVarint();
		[Theory]
		[InlineData(0, new byte[] { 0 })]
		[InlineData(1, new byte[] { 1 })]
		[InlineData(2, new byte[] { 2 })]
		[InlineData(127, new byte[] { 127 })]
		[InlineData(128, new byte[] { 128, 1 })]
		[InlineData(255, new byte[] { 255, 1 })]
		[InlineData(2097151, new byte[] { 255, 255, 127 })]
		[InlineData(2147483647, new byte[] { 255, 255, 255, 255, 7 })]
		[InlineData(-1, new byte[] { 255, 255, 255, 255, 15 })]
		[InlineData(-2147483648, new byte[] { 128, 128, 128, 128, 8 })]
		public void WriteVarint(int value, byte[] expected)
		{
			// arrange
			using MemoryStream memoryStream = new();
			// act 
			attribute.Write(value, memoryStream);
			var actual = memoryStream.ToArray();
			// assert
			for (int i = 0; i < expected.Length; i++) Assert.Equal(expected[0], actual[0]);
		}

		[Theory]
		[InlineData(0, new byte[] { 0 })]
		[InlineData(1, new byte[] { 1 })]
		[InlineData(2, new byte[] { 2 })]
		[InlineData(127, new byte[] { 127 })]
		[InlineData(128, new byte[] { 128, 1 })]
		[InlineData(255, new byte[] { 255, 1 })]
		[InlineData(2097151, new byte[] { 255, 255, 127 })]
		[InlineData(2147483647, new byte[] { 255, 255, 255, 255, 7 })]
		[InlineData(-1, new byte[] { 255, 255, 255, 255, 15 })]
		[InlineData(-2147483648, new byte[] { 128, 128, 128, 128, 8 })]
		public void ReadVarint(int expected, byte[] array)
		{
			// arrange
			using MemoryStream memoryStream = new(array);
			// act 
			var actual = (int)attribute.Read(memoryStream);
			// assert
			Assert.Equal(actual, expected);
		}
	}
}
