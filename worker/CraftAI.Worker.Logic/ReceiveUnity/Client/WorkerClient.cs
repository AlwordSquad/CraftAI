using Craft.AI.Worker.Interface;
using Serilog;
using System;
using System.Buffers;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.Client
{
	// https://stackoverflow.com/questions/62756874/how-to-use-websockets-in-asp-net-core
	public class WorkerClient
	{
		private WebSocket _socket;
		private readonly WebsocketReader _websocketReader;
		private CancellationTokenSource _cts = new();
		public WorkerClient(WebSocket socket, WebsocketReader websocketReader)
		{
			_socket = socket;
			_websocketReader = websocketReader;
		}
		public async Task RunAsync()
		{
			var readTask = Task.Run(async () => await WriteLoopAsync(), _cts.Token);
			await Task.WhenAny(readTask);
		}
		public async Task WriteLoopAsync()
		{
			Memory<byte> buffer = ArrayPool<byte>.Shared.Rent(4 * 1024);
			while (true)
			{
				try
				{
					var result = await _socket.ReceiveAsync(buffer, _cts.Token);
					var usefulBuffer = buffer[..result.Count].ToArray();
					_websocketReader.Accept(usefulBuffer);
				}
				catch (Exception ex)
				{
					Log.Error(ex, "socket error handling");
				}
			}
		}
	}
}
