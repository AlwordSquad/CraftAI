﻿using System.IO;
using CraftAI.Gate.Logic.LLAPI.Attributes;
using CraftAI.Gate.Logic.Registry.Palettes;

namespace CraftAI.Gate.Logic.Registry
{
	public class ChunkSection
	{
		public const int SizeX = 16;
		public const int SizeY = 16;
		public const int SizeZ = 16;

		public IPalette palette; // palette

		public BlockId[,,] blockIds = new BlockId[16, 16, 16];

		public int[] GetState()
		{
			int index = 0;
			int[] state = new int[SizeX * SizeY * SizeZ];
			for (int x = 0; x < SizeX; x++)
			{
				for (int y = 0; y < SizeY; y++)
				{
					for (int z = 0; z < SizeZ; z++)
					{
						state[index] = checked((ushort)blockIds[x, y, z].StateId);
						index += 1;
					}
				}
			}
			return state;
		}

		public void Parse(Stream data)
		{
			var nonAirBlocksCount = (short)LShort.Convertor.Read(data);
			var bitsPerBlock = (byte)LByte.Convertor.Read(data);
			IPalette palette = Palette.ChoosePalette(bitsPerBlock);
			palette.Read(data);
			uint individualValueMask = (uint)((1 << bitsPerBlock) - 1);

			var dataArray = (ulong[])LULongArray.Convertor.Read(data);

			for (int y = 0; y < SizeY; y++)
			{
				for (int z = 0; z < SizeZ; z++)
				{
					for (int x = 0; x < SizeX; x++)
					{
						int blockNumber = (y * SizeY + z) * SizeZ + x;
						int startLong = blockNumber / (64 / bitsPerBlock);
						int startOffset = (blockNumber - startLong * (64 / bitsPerBlock)) * bitsPerBlock;

						uint intData;
						intData = (uint)(dataArray[startLong] >> startOffset);

						intData &= individualValueMask;

						BlockId state = new BlockId(palette.StateForId(intData).Id);
						SetState(x, y, z, state);
					}
				}
			}
		}

		public void SetState(int x, int y, int z, BlockId state)
		{
			blockIds[x, y, z] = state;
		}

		public BlockId GetBlock(int x, int y, int z)
		{
			return blockIds[x, y, z];
		}

		public void SetBlockLight(int x, int y, int z, int v)
		{
			// Debug.WriteLine($"Set light {x} {y} {z} {v}");
			// throw new NotImplementedException();
		}
	}
}
