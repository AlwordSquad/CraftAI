using CraftAI.Gate.Features.Abstractions;
using CraftAI.Gate.Service;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CraftAI.Gate.Features.Play
{
	public class Connect
	{
		public class Handler : IRequestHandler<BaseRequest<ConnectRequest>>
		{
			public Task<Unit> Handle(BaseRequest<ConnectRequest> request, CancellationToken cancellationToken)
			{
				throw new System.NotImplementedException();
			}
		}
	}
}
