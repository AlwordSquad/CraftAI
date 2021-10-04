using System.Threading.Tasks;

namespace Craft.AI.Worker.Interface.Abstractions
{
	public interface ISender
	{
		string Id { get; }

		Task SendMessage<T>(T message);
	}
}
