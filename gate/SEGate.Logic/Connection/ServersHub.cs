using SEGate.Logic.Abstractions;
using System.Collections.Generic;

namespace SEGate.Logic.Connection
{
	public class ServersHub : IServersHub
	{
		private readonly Dictionary<string, ServerAgents> _hostAgents = new(1);
		private readonly IEventHandlersCollection _handlers;
		private readonly object addServerLock = new object();
		public ServersHub(IEventHandlersCollection eventHandlersCollection)
		{
			_handlers = eventHandlersCollection;
		}


		public ServerAgents EnsureServer(string host)
		{
			if (_hostAgents.ContainsKey(host)) return _hostAgents[host];
			lock (addServerLock)
			{
				if (_hostAgents.ContainsKey(host)) return _hostAgents[host];
				var server = new ServerAgents(host, _handlers);
				_hostAgents.Add(host, server);
				return server;
			}
		}
	}
}
