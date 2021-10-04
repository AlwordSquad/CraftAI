using SEGate.Logic.Abstractions;
using System;
using System.Collections.Generic;

namespace SEGate.Logic.Connection
{
	public class ServerAgents
	{
		private readonly Dictionary<string, AgentConnection> _agentConnection;
		private readonly string _host;
		private readonly IEventHandler[] _eventHandlers;

		public ServerAgents(string host, IEventHandlersCollection handlersCollection = null)
		{
			_agentConnection = new Dictionary<string, AgentConnection>();
			_host = host;
			_eventHandlers = handlersCollection?.EventHandlers ?? Array.Empty<IEventHandler>();
		}
		public AgentConnection CreateAgent(string nickName)
		{
			var agent = new AgentConnection(nickName, _host);
			foreach (var handler in _eventHandlers) agent.Subscribe(handler);
			agent.Connect();
			_agentConnection.Add(nickName, agent);
			return agent;
		}
	}
}
