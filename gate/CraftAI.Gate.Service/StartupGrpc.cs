using CraftAI.Gate.Service.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CraftAI.Gate.Service
{
	public static class StartupGrpc
	{
		public static IServiceCollection AddGrpcClients(this IServiceCollection services, IConfiguration configuration)
		{
			var serviceOptions = configuration.GetSection(ServiceOptions.Section).Get<ServiceOptions>();

			services.AddGrpcClient<CraftAIPlayClientbound.CraftAIPlayClientboundClient>(options =>
			{
				options.Address = new System.Uri(serviceOptions.Worker);
				options.ChannelOptionsActions.Add(s => s.Credentials = Grpc.Core.ChannelCredentials.Insecure);
			});

			return services;
		}
	}
}
