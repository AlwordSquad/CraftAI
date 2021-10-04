using SEGate.Logic.Abstractions;
using SEGate.Logic.LLAPI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEGate.Logic.Connection
{
	public sealed partial class AgentConnection : IAgentConnection
	{
		private Dictionary<Type, IList<IEventHandler>> _eventHandlers = new();
		public void Subscribe<T>(IEventHandler<T> eventHandler) where T : IPacketData => Subscribe(eventHandler);
		public void Subscribe(IEventHandler eventHandler)
		{
			var type = eventHandler.Type;
			if (_eventHandlers.ContainsKey(type))
			{
				var list = _eventHandlers[type];
				list.Add(eventHandler);
			}
			else
			{
				_eventHandlers.Add(type, new List<IEventHandler>() { eventHandler });
			}
		}

		private void Publish(IPacketData packet)
		{
			var type = packet.GetType();
			if (!_eventHandlers.ContainsKey(type)) return;
			foreach (var handler in _eventHandlers[type])
			{
				Task.Factory.StartNew(() => handler.Consume(this, packet));
			}
		}
	}
}
