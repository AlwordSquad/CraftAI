using AutoMapper;
using Craft.AI.Worker.Interface.Network.Clientbound;
using CraftAI.Gate.Service;

namespace CraftAI.Worker.Logic.Profiles
{
	public class SpawnPlayerProfile : Profile
	{
		public SpawnPlayerProfile()
		{
			CreateMap<SpawnPlayer, SetPlayerSpawnDataCommand>()
				.ForMember(e => e.EntityId, (src) => src.MapFrom(w => w.EntityId))
				.ForMember(e => e.PlayerUUUI, (src) => src.MapFrom(w => w.PlayerUUID))
				.ForMember(e => e.X, (src) => src.MapFrom(w => w.X))
				.ForMember(e => e.Y, (src) => src.MapFrom(w => w.Y))
				.ForMember(e => e.Z, (src) => src.MapFrom(w => w.Z))
				.ForMember(e => e.Yaw, (src) => src.MapFrom(w => w.Yaw))
				.ForMember(e => e.Pitch, (src) => src.MapFrom(w => w.Pitch));
		}
	}
}
