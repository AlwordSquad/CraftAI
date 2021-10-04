using Craft.AI.Worker.Interface.Abstractions;
using Craft.AI.Worker.Interface.Network.Serverbound;
using Craft.AI.Worker.Interface.Network.Shared;
using CraftAI.Worker.Logic.EventHandlers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace CraftAI.Worker.Logic.Collections
{
	public class EventHandlerCollection : IEventHub
	{
		private readonly IServiceProvider _serviceProvider;

		private static readonly IReadOnlyDictionary<Type, Type> _keyValuePairs = new Dictionary<Type, Type>
		{
			{ typeof(PingPacket),typeof(PingEventHandler)},
			{ typeof(TerrainRequest),typeof(TerrainRequestEventHandler)}
		};
		public static void Configure(IServiceCollection services)
		{
			services.AddSingleton<PingEventHandler>();
			services.AddSingleton<TerrainRequestEventHandler>();
		}

		public EventHandlerCollection(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}
		public IEventHandler Get(Type type)
		{
			var service = _keyValuePairs[type];
			var instance = _serviceProvider.GetRequiredService(service);
			var handler = (IEventHandler)instance;
			return handler;
		}

	}
}
