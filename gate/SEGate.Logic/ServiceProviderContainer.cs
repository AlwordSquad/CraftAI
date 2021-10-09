using Microsoft.Extensions.DependencyInjection;
using SEGate.Logic.Abstractions;
using SEGate.Logic.Connection;
using SEGate.Logic.EventHandler;

namespace SEGate.Logic
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
