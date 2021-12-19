using AutoMapper;
using CraftAI.Gate.Features.Abstractions;
using CraftAI.Gate.Service;
using CraftAI.Worker.Logic.Services;
using CraftAI.Worker.Logic.Storage;
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
			private readonly IMapper _mapper;

			public Handler(ITerrainService terrainService, IMapper mapper)
			{
				_terrainService = terrainService;
				_mapper = mapper;
			}
			protected override async Task<Void> Handle(Chunk16x16x16 request, CancellationToken cancellationToken)
			{
				Log.Information($"{(nameof(SetChunkData))} {request.X}.{request.Y}.{request.Z}");
				var chunk = _mapper.Map<ChunkDocument>(request);
				await _terrainService.Set(chunk);
				return new Void();
			}
		}
	}
}
