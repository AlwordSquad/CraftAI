using CraftAI.Gate.Logic.LLAPI.Abstractions;
using CraftAI.Gate.Service;

namespace CraftAI.Gate.Logic.Abstractions
{
	public abstract class GrpcPlayEventConvertor<T> : IEventHandler<T> where T : IPacketData
	{
		protected readonly CraftAIPlayClientbound.CraftAIPlayClientboundClient _client;
		public GrpcPlayEventConvertor(CraftAIPlayClientbound.CraftAIPlayClientboundClient client)
		{
			_client = client;
		}
		public abstract void Consume(IAgentConnection agentConnection, T packetData);
	}
}
