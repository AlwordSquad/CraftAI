using CraftAI.Worker.Logic.Services;
using CraftAI.Worker.Logic.Storage;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Xunit;
namespace CraftAI.Worker.Logic.Tests
{
	public class LocalMongoDbTest
	{
		[Fact]
		public async void ConnectUsingMongoDB()
		{
			// arrange
			var config = new ConfigurationBuilder()
				.AddInMemoryCollection(new Dictionary<string, string> {
					{ "ConnectionStrings:MongoDB", "mongodb://localhost:27017" }
				});
			var configuration = config.Build();
			var terraint = new TerrainMongoDb(configuration);
			var expected = new ChunkDocument(1, 2, 3)
			{
				Data = new[] { 4, 5, 6 }
			};
			// act
			await terraint.Set(expected);
			var actual = await terraint.Get(1, 2, 3);
			// assert
			Assert.Equal(expected.Positions, actual.Positions);
			Assert.Equal(expected.Data, actual.Data);
		}
	}
}
