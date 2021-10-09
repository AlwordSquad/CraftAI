using Microsoft.Extensions.DependencyInjection;
using SEGate.Logic.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEGate.Logic.EventHandler
{
	public class EventHandlers : IEventHandlersCollection
	{
		private static Type[] types = Array.Empty<Type>();
		private readonly IEventHandler[] _eventHandlers;
		IEventHandler[] IEventHandlersCollection.EventHandlers => _eventHandlers;

		public EventHandlers(IServiceProvider serviceProvider)
		{
			if (!types.Any()) throw new InvalidOperationException(
				$"Event handlers not found. " +
				$"Call {nameof(EventHandlers)}{nameof(EventHandlers.RegisterCollections)} first");

			List<IEventHandler> list = new(types.Length);

			foreach (var type in types)
			{
				var obj = (IEventHandler)serviceProvider.GetRequiredService(type);
				if (obj is null) throw new ArgumentNullException($"Object {type.Name} is not {nameof(IEventHandler)}");
				list.Add(obj);
			}

			_eventHandlers = list.ToArray();
		}

		public static IServiceCollection RegisterCollections(IServiceCollection services)
		{
			services.AddSingleton<IEventHandlersCollection, EventHandlers>();
			var assembly = typeof(EventHandlers).Assembly
				.GetTypes()
				.Where(e => e.IsClass)
				.Where(e => !e.IsAbstract)
				.Where(e => e.GetInterface(nameof(IEventHandler)) is not null)
				.ToArray();
			foreach (var type in assembly)
			{
				services.AddSingleton(type);
			}
			types = assembly;
			return services;
		}
	}
}
