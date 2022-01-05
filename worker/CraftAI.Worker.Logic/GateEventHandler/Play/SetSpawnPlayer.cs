using AutoMapper;
using Craft.AI.Worker.Interface.Network.Clientbound;
using CraftAI.Gate.Features.Abstractions;
using CraftAI.Gate.Service;
using CraftAI.Worker.Logic.Client;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.GateApiService.Play
{
	public class SetSpawnPlayer
	{
		public class Handler : BaseRequestHandler<SpawnPlayer, Void>
		{
			private readonly IWebHub _clients;
			private readonly IMapper _mapper;

			public Handler(IWebHub clients, IMapper mapper)
			{
				_clients = clients;
				_mapper = mapper;
			}
			protected override Task<Void> Handle(SpawnPlayer request, CancellationToken cancellationToken)
			{
				Log.Information($"{(nameof(SpawnPlayer))} {request.EntityId} {request.X}.{request.Y}.{request.Z}");
				var playerData = _mapper.Map<SetPlayerSpawnDataCommand>(request);
				_clients.All(client => client.SendMessage(playerData));
				return Task.FromResult(new Void());
			}
		}
	}
}
