using CraftAI.Worker.Logic.Services.Agent;
using System;
using System.Collections.Generic;

namespace CraftAI.Worker.Logic.Services.SandboxState
{
	public interface ISandboxSate : IDisposable
	{
		public string URI { get; }
		public IReadOnlyDictionary<string, IAgent> Agents { get; }
	}
	public class ActualSandboxState : ISandboxSate
	{
		private readonly Dictionary<string, IAgent> _agents = new();
		public string URI { get; set; } = "localhost:25565";
		public IReadOnlyDictionary<string, IAgent> Agents => _agents;
		void IDisposable.Dispose()
		{
			_agents.Clear();
			GC.SuppressFinalize(this);
		}
	}
}
