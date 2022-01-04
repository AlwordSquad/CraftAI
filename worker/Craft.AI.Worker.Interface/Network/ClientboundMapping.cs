using Craft.AI.Worker.Interface.Network.Clientbound;
using Craft.AI.Worker.Interface.Network.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Craft.AI.Worker.Interface
{
	public class ClientboundMapping
	{
		public static readonly IReadOnlyDictionary<byte, Type> Types = new Dictionary<byte, Type>
		{
			{ 1, typeof(PingPacket) },
			{ 2, typeof(SetChunkRenderCommand) },
			{ 3, typeof(SetPlayerSpawnDataCommand) },
			{ 4, typeof(CreateSandboxResponse) },
		};

		public static readonly IReadOnlyDictionary<Type, byte> Bytes = Types.ToDictionary(e => e.Value, e => e.Key);
	}
}
