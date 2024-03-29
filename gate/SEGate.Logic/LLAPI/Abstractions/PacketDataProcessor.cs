﻿using System;
using System.IO;
using System.Linq;
using System.Reflection;
using CraftAI.Gate.Logic.LLAPI.Attributes;

namespace CraftAI.Gate.Logic.LLAPI.Abstractions
{
	public abstract class PacketDataProcessor
	{
		public void Deconstruct(IPacketData packet, Stream stream)
		{
			var props = packet.GetType()
				.GetProperties()
				.Where(prop => prop.GetCustomAttributes()
					.Any(e => e.GetType().BaseType == typeof(LType))
				);

			foreach (var prop in props)
			{
				var writerType = prop.GetCustomAttribute(typeof(LType), true);
				var writer = (LType)Activator.CreateInstance(writerType.GetType());
				Handle(prop, packet, stream, writer);
			}
		}

		protected abstract void Handle(PropertyInfo prop, IPacketData packet, Stream stream, LType type);
	}
}
