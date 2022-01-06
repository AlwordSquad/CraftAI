using Craft.AI.Worker.Interface.Abstractions;
using Craft.AI.Worker.Interface.Network.Serverbound;
using Craft.AI.Worker.Interface.Network.Shared;
using Craft.AI.Worker.Interface.Network.Workerbound;
using CraftAI.Worker.Logic.ClientEventHandlers;
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
			{ typeof(TerrainRequest),typeof(TerrainRequestEventHandler)},
			{ typeof(CreateAgentRequest),typeof(CreateAgentEventHandler)},
			{ typeof(CreateSandboxRequest),typeof(CreateSandboxRequestHandler)},
			{ typeof(GetSandboxesRequest),typeof(GetSandboxesRequestHandler)},
			{ typeof(RemoveSandboxRequest),typeof(RemoveSandboxRequestHandler)},
			{ typeof(ConnectSandboxRequest),typeof(ConnectSandboxRequestHandler)},
		};
		public static void Configure(IServiceCollection services)
		{
			services.AddSingleton<PingEventHandler>();
			services.AddSingleton<TerrainRequestEventHandler>();
			services.AddSingleton<CreateSandboxRequestHandler>();
			services.AddSingleton<GetSandboxesRequestHandler>();
			services.AddSingleton<RemoveSandboxRequestHandler>();
			services.AddSingleton<ConnectSandboxRequestHandler>();
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
