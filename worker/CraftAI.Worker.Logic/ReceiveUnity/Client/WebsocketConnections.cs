using Craft.AI.Worker.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CraftAI.Worker.Logic.Client
{
	public interface IWebHub
	{
		public string Add(IWeb sender);
		public void Remove(string senderId);
		public IWeb[] All();
		public void All(Action<IWeb> action);
	}
	public class CraftAiClients : IWebHub
	{
		private readonly Dictionary<string, IWeb> _senders = new();
		public string Add(IWeb sender) { _senders.Add(sender.Id, sender); return sender.Id; }
		public void Remove(string senderId) => _senders.Remove(senderId);
		public IWeb[] All() => _senders.Values.ToArray();
		public void All(Action<IWeb> action)
		{
			foreach (var client in All())
			{
				action.Invoke(client);
			}
		}
	}
}
