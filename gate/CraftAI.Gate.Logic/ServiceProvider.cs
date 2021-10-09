using Microsoft.Extensions.DependencyInjection;

namespace CraftAI.Gate.Logic
{
	public static class ServiceProvider
	{
		public static IServiceCollection AddCraftAIFeatures(this IServiceCollection services)
		{
			return services;
		}
	}
}
