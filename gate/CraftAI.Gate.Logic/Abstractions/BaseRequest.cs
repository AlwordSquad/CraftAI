using MediatR;

namespace CraftAI.Gate.Features.Abstractions
{
	public struct BaseRequest<T> : IRequest
	{
		public T Value { get; set; }
	}
}
