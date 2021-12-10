using MessagePack;
using System.Threading.Tasks;

namespace Craft.AI.Worker.Interface.Abstractions
{
	public interface IEventHandler
	{
		Task Handle(IUIClient sender, byte[] value);
	}
	public abstract class BaseEventHandler<T> : IEventHandler
	{
		public Task Handle(IUIClient sender, byte[] data)
		{
			var result = MessagePackSerializer.Deserialize<T>(data);
			return Handle(sender, result);
		}
		protected abstract Task Handle(IUIClient sender, T value);
	}
}
