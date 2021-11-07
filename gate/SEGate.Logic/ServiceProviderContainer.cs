using CraftAI.Gate.Logic.Abstractions;
using CraftAI.Gate.Logic.Connection;
using CraftAI.Gate.Logic.EventHandler.Collection;
using Microsoft.Extensions.DependencyInjection;

namespace CraftAI.Gate.Logic
{
	public static class ServiceProviderContainer
	{
		public static IServiceCollection AddSEGate(this IServiceCollection services)
		{
			services.AddSingleton<IServersHub, ServersHub>();
			EventHandlers.RegisterCollections(services);
			return services;
		}
	}
}
