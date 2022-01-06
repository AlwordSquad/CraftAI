using System;

namespace CraftAI.Worker.Logic.Services.SandboxState
{
	public interface ISandboxSate : IDisposable
	{

	}
	public class ActualSandboxState : ISandboxSate
	{
		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
