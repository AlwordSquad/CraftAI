using CraftAI.Gate.Features.Abstractions;
using CraftAI.Gate.Service;
using CraftAI.Worker.Logic.Services;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.GateApiService.Play
{
	public class SetChunkData
	{
		public class Handler : BaseRequestHandler<Chunk16x16x16, Void>
		{
			private readonly ITerrainService _terrainService;
			public Handler(ITerrainService terrainService)
			{
				_terrainService = terrainService;
			}
			protected override async Task<Void> Handle(Chunk16x16x16 request, CancellationToken cancellationToken)
			{
				Log.Information($"{(nameof(SetChunkData))} {request.X}.{request.Y}.{request.Z}");
				await _terrainService.Set(request);
				return new Void();
			}
		}
	}
}
