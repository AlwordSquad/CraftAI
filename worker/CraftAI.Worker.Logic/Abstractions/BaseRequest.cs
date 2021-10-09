using MediatR;

namespace CraftAI.Worker.Logic.Abstractions
{
	public class BaseRequest<T> : IRequest
	{
		public BaseRequest(T value) { Value = value; }
		public T Value { get; set; }
	}
}
