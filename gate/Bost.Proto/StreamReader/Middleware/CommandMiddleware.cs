﻿using Bost.Proto.Extentions;
using Bost.Proto.Packet;
using Bost.Proto.StreamReader.Enum;
using Bost.Proto.StreamReader.Model;
using Bost.Proto.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bost.Proto.StreamReader.Middleware
{
	public class CommandMiddleware : McMiddleware
	{
		private readonly static int MAX_LENGTH = 80;
		public static Dictionary<PacketKey, Type> packets;
		public CommandMiddleware(McRequestDelegate _next) : base(_next)
		{
			GetPackets();
		}

		public override void Invoke(McConnectionContext ctx)
		{
			var array = ctx.Data;
			McVarint.TryParse(ref array, out int packetId);
			ctx.PacketId = packetId;
			ctx.Data = array;

			var key = new PacketKey(ctx.PacketId, ctx.ConnectionState, ctx.BoundTo);


			if (packets.ContainsKey(key))
			{
				var packet = (BasePacket)Activator.CreateInstance(packets[key]);
				try
				{
					packet.Read(ctx.Data);
				}
				catch
				{
					Console.WriteLine($"Error 0x{packetId:X02} " +
						$"on {ctx.ConnectionState} " +
						$"to {ctx.BoundTo} " +
						$"with {Convert.ToBase64String(ctx.Data)}");
				}

				ctx.packetEventHub.Invoke(key, packet);
				ctx.genericEventHub.Invoke(packets[key], packet);
				Program.Log($"0x{ctx.PacketId:X02} | {ctx.ConnectionState} | {ctx.BoundTo} | {packet}");
				Program.Log($"0x{ctx.PacketId:X02} | Data | {ctx.Data.ToHexString()}");
			}
			else
			{
				string packetMessage = ctx.Data.ToHexString();
				if (packetMessage.Length > MAX_LENGTH)
					packetMessage = $"{packetMessage.Remove(MAX_LENGTH)}...";
				Program.Log($"1x{ctx.PacketId:X02} | {ctx.ConnectionState} | {ctx.BoundTo} | {packetMessage}");
			}
			_next?.Invoke(ctx);
		}

		public static void GetPackets()
		{
			if (packets == null)
			{
				packets = new Dictionary<PacketKey, Type>();

				var q = (from t in Assembly.GetExecutingAssembly().GetTypes()
						 where t.IsClass && !t.IsAbstract && t.Namespace.StartsWith("Bost.Proto.Packet")
						 select t).ToArray();

				foreach (var t in q)
				{
					var packet = (BasePacket)Activator.CreateInstance(t);

					ConnectionStates connectionState = ConnectionStates.Handshaking;
					Bounds bounds = Bounds.Client;
					if (t.Namespace.Contains("Serverbound"))
						bounds = Bounds.Server;
					if (t.Namespace.Contains("Packet.Handshaking"))
						connectionState = ConnectionStates.Handshaking;

					if (t.Namespace.Contains("Packet.Login"))
						connectionState = ConnectionStates.Login;

					if (t.Namespace.Contains("Packet.Play"))
						connectionState = ConnectionStates.Play;

					if (t.Namespace.Contains("Packet.Status"))
						connectionState = ConnectionStates.Status;

					packets.Add(new PacketKey(packet.PacketId, connectionState, bounds), t);
				}
			}
		}
	}
}
