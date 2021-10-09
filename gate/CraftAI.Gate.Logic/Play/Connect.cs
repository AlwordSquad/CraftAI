using CraftAI.Gate.Features.Abstractions;
using CraftAI.Gate.Service;
using SEGate.Logic.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace CraftAI.Gate.Features.Play
{
	public class Connect
	{
		public class Handler : BaseRequestHandler<ConnectRequest, ConnectResponse>
		{
			private readonly IServersHub _serversHub;

			public Handler(IServersHub serversHub)
			{
				_serversHub = serversHub;
			}

			protected override Task<ConnectResponse> Handle(ConnectRequest request, CancellationToken cancellationToken)
			{
				var server = _serversHub.EnsureServer(request.ServerUri);
				var agent = server.CreateAgent(request.Nickname);
				var response = new ConnectResponse()
				{
					Uuid = agent.UUID.ToString()
				};
				return Task.FromResult(response);
			}
		}
	}
}
