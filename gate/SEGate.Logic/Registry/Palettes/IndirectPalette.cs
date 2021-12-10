using System;
using System.Collections.Generic;
using System.IO;
using CraftAI.Gate.Logic.LLAPI.Attributes;
using CraftAI.Gate.Logic.Registry.Generator;

namespace CraftAI.Gate.Logic.Registry.Palettes
{
	public class IndirectPalette : IPalette
	{
		Dictionary<uint, BlockState> idToState;
		Dictionary<BlockState, uint> stateToId;
		byte bitsPerBlock;

		public IndirectPalette(byte palBitsPerBlock)
		{
			bitsPerBlock = palBitsPerBlock;
		}

		public uint IdForState(BlockState state)
		{
			return stateToId[state];
		}

		public byte GetBitsPerBlock()
		{
			return bitsPerBlock;
		}

		public void Read(Stream data)
		{
			idToState = new Dictionary<uint, BlockState>();
			stateToId = new Dictionary<BlockState, uint>();
			var length = (int)LVarint.Convertor.Read(data);
			for (uint id = 0; id < length; id++)
			{
				var stateId = (int)LVarint.Convertor.Read(data);
				BlockState state = GlobalPalette.GetState((uint)stateId);
				idToState[id] = state;
				stateToId[state] = id;
			}
		}
		public BlockState StateForId(uint id) => idToState[id];

		public void Write(byte[] data)
		{
			throw new NotImplementedException();
		}
	}
}
