using Craft.AI.Worker.Interface.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CraftAI.Worker.Logic.Client
{
	public interface IWebHub
	{
		public string Add(ISender sender);
		public void Remove(string senderId);
		public ISender[] All();
		public void All(Action<ISender> action);
	}
	public class CraftAiClients : IWebHub
	{
		private readonly Dictionary<string, ISender> _senders = new();
		public string Add(ISender sender) { _senders.Add(sender.Id, sender); return sender.Id; }
		public void Remove(string senderId) => _senders.Remove(senderId);
		public ISender[] All() => _senders.Values.ToArray();
		public void All(Action<ISender> action)
		{
			foreach (var client in All())
			{
				action.Invoke(client);
			}
		}
	}
}
