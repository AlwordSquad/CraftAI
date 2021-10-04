using SEGate.Logic.Utils;
using System.Collections.Generic;


namespace SEGate.Logic.Registry.Generator
{
	public static class GlobalPalette
	{
		/// <summary>
		/// Todo generate Blocks enum
		/// </summary>
		private static Dictionary<string, GeneratedBlock> NameToState { get; set; }
		private static Dictionary<BlockId, BlockState> IdToState { get; set; }
		private static Dictionary<BlockState, BlockId> StateToId { get; set; }
		public static readonly uint TotalNumberOfStates;
		static GlobalPalette()
		{
			TotalNumberOfStates = 0;
			string json = ResourceReader.GetStringAsync("blocks.json").GetAwaiter().GetResult();
			Dictionary<string, GeneratedBlock> blocks = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, GeneratedBlock>>(json);

			NameToState = new Dictionary<string, GeneratedBlock>();
			IdToState = new Dictionary<BlockId, BlockState>();
			StateToId = new Dictionary<BlockState, BlockId>();

			foreach (var name in blocks.Keys)
			{
				var blockInfo = blocks[name];
				NameToState.Add(name, blockInfo);
				foreach (var state in blockInfo.States)
				{
					BlockId id = new() { StateId = state.Id };
					BlockState blockState = new() { Id = state.Id, Name = name };
					IdToState.Add(id, blockState);
					StateToId.Add(blockState, id);
					TotalNumberOfStates += 1;
				}
			}
		}

		public static BlockState GetState(uint blockId) => IdToState[new BlockId() { StateId = blockId }];
		public static BlockId GetId(BlockState state) => StateToId[state];
	}
}
