using CraftAI.Gate.Service;
using CraftAI.Gate.Service.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CraftAI.Gate.Contract
{
	public class GrpcGateWorker : IGateWorker
	{
		public static void AddClients(IServiceCollection services, IConfiguration configuration)
		{
			var serviceOptions = configuration.GetSection(ServiceOptions.Section).Get<ServiceOptions>();
			services.AddGrpcClient<CraftAIPlayClientbound.CraftAIPlayClientboundClient>(options =>
			{
				options.Address = new System.Uri(serviceOptions.Worker);
				options.ChannelOptionsActions.Add(s => s.Credentials = Grpc.Core.ChannelCredentials.Insecure);
			});
			services.AddTransient<IGateWorker, GrpcGateWorker>();
		}
		private readonly CraftAIPlayClientbound.CraftAIPlayClientboundClient _playClientboundClient;
		public GrpcGateWorker(CraftAIPlayClientbound.CraftAIPlayClientboundClient playClientboundClient)
		{
			_playClientboundClient = playClientboundClient;
		}
		public async Task SetChunkData(Chunk16x16x16 chunk)
			=> await _playClientboundClient.ChunkDataAsync(chunk);

		public async Task SpawnPlayerAsync(SpawnPlayer player)
			=> await _playClientboundClient.SpawnPlayerAsync(player);
	}
}
