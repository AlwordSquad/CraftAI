using CraftAI.Gate.Contract;
using CraftAI.Gate.Logic.LLAPI.Abstractions;

namespace CraftAI.Gate.Logic.Abstractions
{
	public abstract class GrpcPlayEventConvertor<T> : IEventHandler<T> where T : IPacketData
	{
		protected readonly IGateWorker _client;
		public GrpcPlayEventConvertor(IGateWorker client)
		{
			_client = client;
		}
		public abstract void Consume(IAgentConnection agentConnection, T packetData);
	}
}
