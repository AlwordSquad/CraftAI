using Craft.AI.Worker.Interface.Abstractions;
using CraftAI.Worker.Logic.Collections;
using CraftAI.Worker.Logic.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CraftAI.Worker.Logic
{
	public static class ServiceProvision
	{
		public static IServiceCollection AddCraftAIWorker(this IServiceCollection services)
		{
			services.AddMediatR(typeof(ServiceProvision));
			services.AddSingleton<ITerrainService, TerrainDev>();
			services.AddSingleton<IEventHub, EventHandlerCollection>();
			EventHandlerCollection.Configure(services);

			return services;
		}
	}
}
