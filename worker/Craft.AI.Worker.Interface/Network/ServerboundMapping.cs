using Craft.AI.Worker.Interface.Network.Serverbound;
using Craft.AI.Worker.Interface.Network.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Craft.AI.Worker.Interface
{
	public class ServerboundMapping
	{
		public static readonly IReadOnlyDictionary<byte, Type> Types = new Dictionary<byte, Type>
		{
			{ 1, typeof(PingPacket) },
			{ 2, typeof(TerrainRequest) }
		};

		public static readonly IReadOnlyDictionary<Type, byte> Bytes = Types.ToDictionary(e => e.Value, e => e.Key);
	}
}
