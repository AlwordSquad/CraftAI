﻿using System;
using System.IO;
using CraftAI.Gate.Logic.Registry.Generator;

namespace CraftAI.Gate.Logic.Registry.Palettes
{
	public class DirectPalette : IPalette
	{
		public byte GetBitsPerBlock()
		{
			return (byte)Math.Ceiling(Math.Log2(GlobalPalette.TotalNumberOfStates)); // currently 14
		}
		public uint IdForState(BlockState state)
		{
			return GlobalPalette.GetId(state).StateId;
		}
		public void Read(Stream data)
		{
			// no data
		}
		public BlockState StateForId(uint id) => GlobalPalette.GetState(id);
		public void Write(byte[] data) => throw new NotImplementedException();
	}
}
