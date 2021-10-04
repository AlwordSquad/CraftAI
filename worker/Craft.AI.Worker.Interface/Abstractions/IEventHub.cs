using System;

namespace Craft.AI.Worker.Interface.Abstractions
{
	public interface IEventHub
	{
		IEventHandler Get(Type type);
	}
}
