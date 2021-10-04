using Microsoft.Extensions.DependencyInjection;

namespace SEGate.Logic
{
	public static class ServiceProviderContainer
	{
		public static IServiceCollection AddSEGate(this IServiceCollection services)
		{
			return services;
		}
	}
}
