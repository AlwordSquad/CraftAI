using CraftAI.Gate.Logic.Registry.Generator;

namespace CraftAI.Gate.Logic.Registry
{
	public record BlockId
	{
		public uint StateId { get; set; }
		public BlockId(uint id = 0) => StateId = id;
		public override string ToString() => $"{StateId} {GlobalPalette.GetState(StateId).Name}";
	}
}
