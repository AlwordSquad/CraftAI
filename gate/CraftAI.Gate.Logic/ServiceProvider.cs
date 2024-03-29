﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CraftAI.Gate.Features
{
	public static class ServiceProvider
	{
		public static IServiceCollection AddCraftAIFeatures(this IServiceCollection services)
		{
			services.AddMediatR(typeof(ServiceProvider));
			return services;
		}
	}
}
