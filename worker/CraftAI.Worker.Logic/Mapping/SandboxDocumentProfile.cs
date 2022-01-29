using AutoMapper;
using Craft.AI.Worker.Interface.Network.Clientbound;
using Craft.AI.Worker.Interface.Network.Serverbound;
using CraftAI.Worker.Logic.Services.Sandbox;

namespace CraftAI.Worker.Logic.Mapping
{
	public class SandboxDocumentProfile : Profile
	{
		public SandboxDocumentProfile()
		{
			CreateMap<SandboxDocument, SandboxItem>();
			CreateMap<CreateSandboxRequest, SandboxDocument>();
		}
	}
}
