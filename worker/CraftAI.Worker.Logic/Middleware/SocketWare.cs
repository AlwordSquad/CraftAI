using Craft.AI.Worker.Interface;
using Craft.AI.Worker.Interface.Abstractions;
using CraftAI.Worker.Logic.Client;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.Middleware
{
	public class SocketWare
	{
		private RequestDelegate _next;
		private readonly IEventHub _eventHub;
		private readonly IUIClients _clients;

		public SocketWare(RequestDelegate next, IEventHub eventHub, IUIClients clients)
		{
			_next = next;
			_eventHub = eventHub;
			_clients = clients;
		}
		public async Task Invoke(HttpContext context)
		{
			if (context.WebSockets.IsWebSocketRequest)
			{
				using var socket = await context.WebSockets.AcceptWebSocketAsync();
				await RunAsync(socket);
			}
			else
			{
				await _next.Invoke(context);
			}
		}

		private async Task RunAsync(WebSocket socket)
		{
			string senderId = string.Empty;
			try
			{
				var sender = new WebsocketSender(socket);
				senderId = _clients.Add(sender);
				var reader = new WebsocketReader(sender, ServerboundMapping.Types, _eventHub);
				var client = new WorkerClient(socket, reader);
				await client.RunAsync();
			}
			catch (Exception ex)
			{
				Log.Error(ex, $"Web-socket connection error for {nameof(SocketWare)}");
				_clients.Remove(senderId);
			}
		}
	}
}
