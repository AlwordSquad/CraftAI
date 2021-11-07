using System.Threading.Tasks;

namespace Craft.AI.Worker.Interface.Abstractions
{
	public interface IUIClient
	{
		string Id { get; }

		Task SendMessage<T>(T message);
	}
}
