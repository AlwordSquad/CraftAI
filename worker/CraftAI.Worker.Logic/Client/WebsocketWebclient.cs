using Craft.AI.Worker.Interface;
using Craft.AI.Worker.Interface.Abstractions;
using Craft.AI.Worker.Interface.Network.Clientbound;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.Client
{
	internal class WebsocketWebclient : IWeb
	{
		private readonly ISender _sender;
		public WebsocketWebclient(ISender sender) => _sender = sender;
		public Task SetSandboxList(CreateSandboxResponse response) => _sender.SendMessage(response);
	}
}
