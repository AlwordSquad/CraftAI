using Xunit;
namespace CraftAI.Worker.Logic.Tests
{
	public class UnitTest1
	{
		[Fact]
		public void ConnectUsingGrpc()
		{
			var grpcChannel = new Grpc.Core.Channel("localhost", 5001, Grpc.Core.ChannelCredentials.Insecure);
			var gate = new CraftAI.Gate.Service.CraftAIPlayServerbound.CraftAIPlayServerboundClient(grpcChannel);
			var result = gate.Connect(new Gate.Service.ConnectRequest()
			{
				ServerUri = "localhost:25565",
				Nickname = "TestAlword"
			});
			Assert.NotEmpty(result.Uuid);
		}
	}
}
