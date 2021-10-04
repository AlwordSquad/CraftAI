using Craft.AI.Worker.Interface.Abstractions;
using Craft.AI.Worker.Interface.Network.Clientbound;
using Craft.AI.Worker.Interface.Network.Serverbound;
using CraftAI.Worker.Logic.Services;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.EventHandlers
{
	public class TerrainRequestEventHandler : BaseEventHandler<TerrainRequest>
	{
		private readonly ITerrainService _terrainService;
		public TerrainRequestEventHandler(ITerrainService terrainService)
		{
			_terrainService = terrainService;
		}

		protected override async Task Handle(ISender sender, TerrainRequest value)
		{
			foreach (var pos in value.Positions)
			{
				var chunk = await _terrainService.Get(pos.X, pos.Z);
				await sender.SendMessage(new SetChunkRenderCommand()
				{
					ChunkPosition = chunk.Coord,
					Triangles = chunk.Triangles,
					Vertices = chunk.Vertices,
					Uvs = chunk.Uvs,
				});

			}
		}
	}
}
