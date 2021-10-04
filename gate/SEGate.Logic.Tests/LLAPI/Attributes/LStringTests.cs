using SEGate.Logic.LLAPI.Attributes;
using System.IO;
using Xunit;

namespace SEGate.Logic.Tests.LLAPI.Attributes
{
	public class LStringTests
	{
		private readonly LString attribute = new();
		[Theory]
		[InlineData("Hello")]
		[InlineData("Привет")]
		[InlineData("127.0.0.1")]
		public void UseLString(string expected)
		{
			// arrange
			using MemoryStream memoryStream = new();
			// act 
			attribute.Write(expected, memoryStream);
			memoryStream.Seek(0, SeekOrigin.Begin);
			var value = attribute.Read(memoryStream);
			var actual = (string)value;
			// assert
			Assert.Equal(actual, value);
		}
	}
}
