namespace CraftAI.Gate.Logic.Abstractions
{
	public interface IEventHandlersCollection
	{
		public IEventHandler[] EventHandlers { get; }
	}
}
