using Craft.AI.Worker.Interface;
using Craft.AI.Worker.Interface.Abstractions;
using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.Client
{
	public class WebsocketSender : IUIClient
	{
		private readonly WebSocket _webSocket;
		private static readonly PacketWriter packetWriter = new PacketWriter(ClientboundMapping.Bytes);
		public string Id => new Guid().ToString();
		public WebsocketSender(WebSocket webSocket)
		{
			_webSocket = webSocket;
		}

		public async Task SendMessage<T>(T message)
		{
			var bytes = packetWriter.WriteData(message);
			await _webSocket.SendAsync(bytes, WebSocketMessageType.Binary, true, CancellationToken.None);
		}
	}
}
