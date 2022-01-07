using Craft.AI.Worker.Interface;
using CraftAI.Worker.Logic.Services.SandboxState;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.Abstractions
{
	public abstract class BaseSandboxEventHandler<T> : BaseWebEventHandler<T>
	{
		private readonly ISandboxHub _hub;
		public BaseSandboxEventHandler(ISandboxHub sandboxHub)
		{
			_hub = sandboxHub;
		}
		protected override Task Handle(IWeb sender, T value)
		{
			var sandBox = _hub.GetState(sender.SandboxId);
			return Handle(sender, sandBox, value);
		}
		protected abstract Task Handle(IWeb sender, ISandboxSate sandbox, T value);
	}
}
