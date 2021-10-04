using Craft.AI.Worker.Interface.Network.Shared;
using MessagePack;

namespace Craft.AI.Worker.Interface.Network.Serverbound
{
	[MessagePackObject]
	public class TerrainRequest
	{
		[Key(1)]
		public ChunkPosition[] Positions { get; set; }
	}
}
