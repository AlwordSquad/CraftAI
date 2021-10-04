using System;
using System.Collections.Generic;

namespace Craft.AI.Worker.Interface.Extensions
{
	public static class QueueExtensions
	{
		public static void EnqueueRange<T>(this Queue<T> queue, IEnumerable<T> enu)
		{
			lock (queue)
			{
				foreach (T obj in enu) queue.Enqueue(obj);
			}
		}

		public static T[] DequeueRange<T>(this Queue<T> queue, uint count)
		{
			if (count <= 0) return Array.Empty<T>();
			if (count > queue.Count) throw new ArgumentOutOfRangeException($"Queue range {queue.Count} is less then dequeue count {count}");
			var array = new T[count];
			lock (queue)
			{
				// TODO: to array and Re queue benchmark
				// or List<byte> queue implementation
				for (int i = 0; i < count; i++)
				{
					array[i] = queue.Dequeue();
				}
			}
			return array;
		}
	}
}
