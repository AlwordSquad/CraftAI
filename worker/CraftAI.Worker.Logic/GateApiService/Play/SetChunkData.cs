using CraftAI.Gate.Service;
using CraftAI.Worker.Logic.Abstractions;
using CraftAI.Worker.Logic.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.GateApiService.Play
{
	public class SetChunkData
	{
		public class Handler : IRequestHandler<BaseRequest<Chunk16x16x16>>
		{
			private readonly ITerrainService _terrainService;
			public Handler(ITerrainService terrainService)
			{
				_terrainService = terrainService;
			}
			public async Task<Unit> Handle(BaseRequest<Chunk16x16x16> request, CancellationToken cancellationToken)
			{
				await _terrainService.Set(request.Value);
				return Unit.Value;
			}
		}
	}
}
