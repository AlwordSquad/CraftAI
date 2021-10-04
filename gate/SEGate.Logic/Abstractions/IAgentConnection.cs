using SEGate.Logic.LLAPI;
using System;
using System.Threading;

namespace SEGate.Logic.Abstractions
{
	public interface IAgentConnection : IDisposable
	{
		public Guid UUID { get; }
		public string Username { get; }
		CancellationToken Connect();
		void Send(IPacketData packetData);
		void Subscribe<T>(IEventHandler<T> eventHandler) where T : IPacketData;
		void Subscribe(IEventHandler eventHandler);
	}
}
