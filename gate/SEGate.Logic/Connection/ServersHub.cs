using System.Collections.Generic;
using CraftAI.Gate.Logic.Abstractions;

namespace CraftAI.Gate.Logic.Connection
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
