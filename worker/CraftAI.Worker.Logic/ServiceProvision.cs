﻿using Craft.AI.Worker.Interface.Abstractions;
using CraftAI.Gate.Contract;
using CraftAI.Worker.Logic.Client;
using CraftAI.Worker.Logic.Collections;
using CraftAI.Worker.Logic.Services;
using CraftAI.Worker.Logic.Services.Sandbox;
using CraftAI.Worker.Logic.Services.SandboxState;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CraftAI.Worker.Logic
{
	public static class ServiceProvision
	{
		public static IServiceCollection AddCraftAIWorker(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddMediatR(typeof(ServiceProvision));
			services.AddSingleton<ITerrainService, TerrainMongoDb>();
			services.AddSingleton<IEventHub, EventHandlerCollection>();
			services.AddSingleton<ISandboxStore, SandboxStore>();
			services.AddSingleton<IWebHub, CraftAiClients>();
			services.AddSingleton<ISandboxHub, SandboxHub>();
			services.AddAutoMapper(typeof(ServiceProvision));
			EventHandlerCollection.Configure(services);
			GrpcGate.AddClients(services, configuration);
			return services;
		}
	}
}
