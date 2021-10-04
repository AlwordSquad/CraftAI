using MessagePack;
using System.Threading.Tasks;

namespace Craft.AI.Worker.Interface.Abstractions
{
	public interface IEventHandler
	{
		Task Handle(ISender sender, byte[] value);
	}
	public abstract class BaseEventHandler<T> : IEventHandler
	{
		public Task Handle(ISender sender, byte[] data)
		{
			var result = MessagePackSerializer.Deserialize<T>(data);
			return Handle(sender, result);
		}
		protected abstract Task Handle(ISender sender, T value);
	}
}
