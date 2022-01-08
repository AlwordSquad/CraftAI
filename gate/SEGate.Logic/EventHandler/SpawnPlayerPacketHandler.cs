using CraftAI.Gate.Contract;
using CraftAI.Gate.Logic.Abstractions;
using CraftAI.Gate.Logic.LLAPI.Play.Clientbound;
using CraftAI.Gate.Service;

namespace CraftAI.Gate.Logic.EventHandler
{
	public class SpawnPlayerPacketHandler : GrpcPlayEventConvertor<SpawnPlayerPacket>
	{
		public SpawnPlayerPacketHandler(IGateWorker client) : base(client) { }
		public override async void Consume(IAgentConnection agentConnection, SpawnPlayerPacket packetData)
		{
			await _client.SpawnPlayerAsync(new SpawnPlayer()
			{
				EntityId = packetData.EntityID,
				Pitch = packetData.Pitch,
				X = packetData.X,
				Y = packetData.Y,
				Z = packetData.Z,
				Yaw = packetData.YAW,
				PlayerUUID = packetData.PlayerUUID.ToString(),
			});
		}
	}
}
