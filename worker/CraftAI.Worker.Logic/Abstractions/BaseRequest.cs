using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CraftAI.Gate.Features.Abstractions
{
	public struct BaseRequest<T> : IRequest
	{
		public T Value { get; set; }
	}

	public struct BaseRequest<T, Q> : IRequest<Q>
	{
		public BaseRequest(T request) => Value = request;
		public T Value { get; set; }
	}

	public abstract class BaseRequestHandler<T, Q> : IRequestHandler<BaseRequest<T, Q>, Q>
	{
		public Task<Q> Handle(BaseRequest<T, Q> request, CancellationToken cancellationToken)
		{
			return Handle(request.Value, cancellationToken);
		}

		protected abstract Task<Q> Handle(T request, CancellationToken cancellationToken);
	}
}
