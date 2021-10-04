using Craft.AI.Worker.Interface.Network.Shared;
using MessagePack;

namespace Craft.AI.Worker.Interface.Network.Clientbound
{
	[MessagePackObject]
	public class SetChunkRenderCommand
	{
		[Key(1)] public ChunkPosition ChunkPosition { get; set; }
		[Key(2)] public Int3[] Vertices { get; set; }
		[Key(3)] public int[] Triangles { get; set; }
		[Key(4)] public Float2[] Uvs { get; set; }
	}
}
