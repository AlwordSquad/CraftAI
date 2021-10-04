using Craft.AI.Worker.Interface.Abstractions;
using Craft.AI.Worker.Interface.Extensions;
using System;
using System.Collections.Generic;

namespace Craft.AI.Worker.Interface
{
	public class WebsocketReader
	{
		private const int NoData = 0;

		private readonly Queue<byte> _queue = new Queue<byte>(4 * 1024);
		private readonly ISender _sender;
		private readonly IReadOnlyDictionary<byte, Type> _mapping;
		private readonly IEventHub _eventHub;
		private uint _nextPacketLength = NoData;
		private byte _nextPacketKey = NoData;
		private byte _packetMetaSize = sizeof(int) + 1;
		public WebsocketReader(
			ISender sender,
			IReadOnlyDictionary<byte, Type> mapping,
			IEventHub eventHub)
		{
			_sender = sender;
			_mapping = mapping;
			_eventHub = eventHub;
		}

		public void Accept(byte[] array)
		{
			_queue.EnqueueRange(array);
			if (_nextPacketLength == NoData)
			{
				if (array.Length < _packetMetaSize) return;
				var slice = _queue.DequeueRange(_packetMetaSize);
				_nextPacketLength = BitConverter.ToUInt32(slice, 0);
				_nextPacketKey = slice[slice.Length - 1];
			}
			if (_queue.Count < _nextPacketLength) return;
			var packet = _queue.DequeueRange(_nextPacketLength);
			var type = _mapping[_nextPacketKey];
			FireEvent(type, packet);
		}
		private async void FireEvent(Type type, byte[] value)
		{
			var eventHandler = _eventHub.Get(type);
			await eventHandler.Handle(_sender, value);
		}
	}
}
