using SEGate.Logic.LLAPI;
using System;

namespace SEGate.Logic.Abstractions
{
	public interface IEventHandler
	{
		void Consume(IAgentConnection agentConnection, dynamic packetData);
		Type Type { get; }
	}
	public interface IEventHandler<T> : IEventHandler where T : IPacketData
	{
		void Consume(IAgentConnection agentConnection, T packetData);
		void IEventHandler.Consume(IAgentConnection agentConnection, dynamic packetData) => Consume(agentConnection, (T)packetData);
		Type IEventHandler.Type => typeof(T);
	}
}
