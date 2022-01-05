using AutoMapper;
using Craft.AI.Worker.Interface;
using Craft.AI.Worker.Interface.Network.Clientbound;
using Craft.AI.Worker.Interface.Network.Workerbound;
using CraftAI.Worker.Logic.Abstractions;
using CraftAI.Worker.Logic.Services.Sandbox;
using System;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.ClientEventHandlers
{
	internal class GetSandboxesRequestHandler : BaseWebEventHandler<GetSandboxesRequest>
	{
		private readonly ISandboxStore _sandboxStore;
		private readonly IMapper _mapper;

		public GetSandboxesRequestHandler(ISandboxStore sandboxStore, IMapper mapper)
		{
			_sandboxStore = sandboxStore;
			_mapper = mapper;
		}
		protected override async Task Handle(IWeb sender, GetSandboxesRequest value)
		{
			var all = await _sandboxStore.GetAll();
			var items = _mapper.Map<SandboxItem[]>(all) ?? Array.Empty<SandboxItem>();
			await sender.SetSandboxList(new CreateSandboxResponse()
			{
				SandboxItems = items
			});
		}
	}
}
