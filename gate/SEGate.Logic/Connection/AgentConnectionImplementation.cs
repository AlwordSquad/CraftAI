using SEGate.Logic.LLAPI;
using SEGate.Logic.LLAPI.Abstractions;
using SEGate.Logic.LLAPI.Attributes;
using SEGate.Logic.LLAPI.Handshaking;
using SEGate.Logic.LLAPI.Login;
using SEGate.Logic.LLAPI.Login.Clientbound;
using SEGate.Logic.LLAPI.Login.Serverbound;
using SEGate.Logic.LLAPI.Play;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace SEGate.Logic.Connection
{
	public sealed partial class AgentConnection
	{
		private int compressionLevel = 0;
		private readonly string _address;
		private readonly ushort _port;
		private readonly string _userName;
		private readonly CancellationTokenSource _cancelTokenSource = new();
		private NetworkStream _stream;
		private TcpClient _client;
		private IPacketSender packetSender;
		private void ReceivePlay()
		{
			Stopwatch stopwatch = new();
			var reader = new PacketReader(new PlayClientMapper(), true, compressionLevel) as IPacketReader;
			while (_stream.CanRead && !_cancelTokenSource.IsCancellationRequested)
			{
				stopwatch.Start();
				var packet = reader.ReadPacket(_stream);
				Publish(packet);
				stopwatch.Stop();
				stopwatch.Reset();
			}
		}

		private void SendHandshakeLogin()
		{
			using MemoryStream buffer = new();
			using MemoryStream handshake = new();
			using MemoryStream login = new();
			PacketDataBuilder.Instance.Write(Handshake.Latest(_address, _port), handshake);
			LVarint.Convertor.Write(handshake.Length + 1, buffer);
			LVarint.Convertor.Write(0x0, buffer);
			handshake.Seek(0, SeekOrigin.Begin);
			handshake.CopyTo(buffer);

			PacketDataBuilder.Instance.Write(LoginStart.Nick(_userName), login);
			LVarint.Convertor.Write(login.Length + 1, buffer);
			LVarint.Convertor.Write(0x0, buffer);
			login.Seek(0, SeekOrigin.Begin);
			login.CopyTo(buffer);

			buffer.Seek(0, SeekOrigin.Begin);
			buffer.CopyTo(_stream);
			_stream.Flush();
		}

		private void ReceiveLogin()
		{
			var mapper = new LoginClientboundMapping();
			var reader = new PacketReader(mapper) as IPacketReader;
			do
			{
				var packet = reader.ReadPacket(_stream);

				if (packet is SetCompression compression)
				{
					compressionLevel = compression.Threshold;
					reader = new PacketReader(mapper, compression: true, compressionLevel);
					packetSender = new PacketSender(new PlayServerMapper(), true, compressionLevel);
				}
				else if (packet is LoginSuccess loginSuccess)
				{
					UUID = loginSuccess.UUID;
					Username = loginSuccess.Username;
				};

			} while (UUID == Guid.Empty);
		}

	}
}
