using Microsoft.Extensions.DependencyInjection;
using SEGate.Logic.EventHandler;

namespace SEGate.Logic
{
	public static class ServiceProviderContainer
	{
		public static IServiceCollection AddSEGate(this IServiceCollection services)
		{
			EventHandlers.RegisterCollections(services);
			return services;
		}
	}
}
