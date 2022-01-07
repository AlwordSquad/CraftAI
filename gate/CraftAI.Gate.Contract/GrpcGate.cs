using CraftAI.Gate.Service;
using CraftAI.Gate.Service.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CraftAI.Gate.Contract
{
	public class GrpcGate : IGate
	{
		public static void AddClients(IServiceCollection services, IConfiguration configuration)
		{
			var serviceOptions = configuration.GetSection(ServiceOptions.Section).Get<ServiceOptions>();
			services.AddGrpcClient<CraftAIPlayServerbound.CraftAIPlayServerboundClient>(options =>
			{
				options.Address = new System.Uri(serviceOptions.Gate);
				options.ChannelOptionsActions.Add(s => s.Credentials = Grpc.Core.ChannelCredentials.Insecure);
			});
			services.AddTransient<IGate, GrpcGate>();
		}

		private readonly CraftAIPlayServerbound.CraftAIPlayServerboundClient _channel;
		public GrpcGate(CraftAIPlayServerbound.CraftAIPlayServerboundClient playClientboundClient)
		{
			_channel = playClientboundClient;
		}

		public async Task<ConnectResponse> Connect(ConnectRequest request)
			=> await _channel.ConnectAsync(request);
	}
}
