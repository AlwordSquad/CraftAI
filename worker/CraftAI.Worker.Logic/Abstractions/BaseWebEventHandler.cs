using Craft.AI.Worker.Interface;
using Craft.AI.Worker.Interface.Abstractions;
using CraftAI.Worker.Logic.Client;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.Abstractions
{
	public abstract class BaseWebEventHandler<T> : BaseEventHandler<T>
	{
		protected override Task Handle(ISender sender, T value) => Handle(new WebsocketWebclient(sender), value);
		protected abstract Task Handle(IWeb sender, T value);
	}
}
