using AutoMapper;
using CraftAI.Gate.Service;
using CraftAI.Worker.Logic.Storage;

namespace CraftAI.Worker.Logic.Profiles
{
	public class ChunkDocumentProfile : Profile
	{
		public ChunkDocumentProfile()
		{
			CreateMap<Chunk16x16x16, ChunkDocument>()
				.ForMember(e => e.Positions, s => s.MapFrom(w => ChunkDocument.KeyFrom(w.X, w.Y, w.Z)))
				.ForMember(e => e.Data, e => e.MapFrom((src, _) =>
				{
					var data = new int[src.BlockType.Count];
					src.BlockType.CopyTo(data, 0);
					return data;
				}));
		}
	}
}
