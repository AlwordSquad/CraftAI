using Craft.AI.Worker.Interface.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CraftAI.Worker.Logic.Client
{
	public interface IUIClients
	{
		public string Add(IUIClient sender);
		public void Remove(string senderId);
		public IUIClient[] All();
		public void All(Action<IUIClient> action);
	}
	public class CraftAiClients : IUIClients
	{
		private readonly Dictionary<string, IUIClient> _senders = new();
		public string Add(IUIClient sender) { _senders.Add(sender.Id, sender); return sender.Id}
		public void Remove(string senderId) => _senders.Remove(senderId);
		public IUIClient[] All() => _senders.Values.ToArray();
		public void All(Action<IUIClient> action)
		{
			foreach (var client in All())
			{
				action.Invoke(client);
			}
		}
	}
}
