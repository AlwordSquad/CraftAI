using System.Collections.Generic;

namespace CraftAI.Worker.Logic.Services.SandboxState
{
	public interface ISandboxHub
	{
		public ISandboxSate GetState(string id);
		public void Prune(string id);
		public void Prune();
	}
	public class SandboxHub : ISandboxHub
	{
		private readonly Dictionary<string, ISandboxSate> _sandboxState = new(1);
		public ISandboxSate GetState(string id)
		{
			if (!_sandboxState.TryGetValue(id, out var state))
			{
				state = new ActualSandboxState();
				_sandboxState.Add(id, state);
			}
			return state;
		}

		public void Prune(string id)
		{
			var state = _sandboxState.TryGetValue(id, out var result);
			if (!state || result == null) return;
			result.Dispose();
			_sandboxState.Remove(id);
		}

		public void Prune()
		{
			foreach (var sandbox in _sandboxState)
			{
				sandbox.Value.Dispose();
			}
			_sandboxState.Clear();
		}
	}
}
