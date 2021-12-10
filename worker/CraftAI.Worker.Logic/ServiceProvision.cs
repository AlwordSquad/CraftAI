using Craft.AI.Worker.Interface.Abstractions;
using CraftAI.Worker.Logic.Client;
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
			services.AddSingleton<ITerrainService, TerrainMongoDb>();
			services.AddSingleton<IEventHub, EventHandlerCollection>();
<<<<<<< HEAD
=======
			services.AddSingleton<IUIClients, CraftAiClients>();
>>>>>>> af32b0cb5c329dfafa204ac3eddb57b51d274ebc
			services.AddAutoMapper(typeof(ServiceProvision));
			EventHandlerCollection.Configure(services);
			return services;
		}
	}
}
