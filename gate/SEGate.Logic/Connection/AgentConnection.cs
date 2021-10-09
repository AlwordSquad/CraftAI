using SEGate.Logic.Abstractions;
using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace SEGate.Logic.Connection
{
	public sealed partial class AgentConnection : IAgentConnection
	{
		public string Username { get; private set; }
		public Guid UUID { get; private set; }
		/// <summary>
		/// Create connection to server
		/// </summary>
		/// <param name="userName">minecraft nickname</param>
		/// <param name="host">server ip:port</param>
		public AgentConnection(string userName, string host)
		{
			_userName = userName;
			var serverPort = host.Split(':');
			_address = serverPort[0];
			_port = ushort.Parse(serverPort[1]);
		}

		public CancellationToken Connect()
		{
			if (_stream != null) return _cancelTokenSource.Token;
			lock (_address)
			{
				_client = new TcpClient(_address, _port);
				_stream = _client.GetStream();
			}
			SendHandshakeLogin();
			ReceiveLogin();
			Task.Factory.StartNew(ReceivePlay);
			return _cancelTokenSource.Token;
		}

		public void Dispose()
		{
			_cancelTokenSource.Cancel();
			_stream.Dispose();
			_client.Dispose();
		}
	}
}
