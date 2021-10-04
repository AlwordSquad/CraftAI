namespace SEGate.Logic.Abstractions
{
	public interface IEventHandlersCollection
	{
		public IEventHandler[] EventHandlers { get; }
	}
}
