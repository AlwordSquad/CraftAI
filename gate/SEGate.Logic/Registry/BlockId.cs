using SEGate.Logic.Registry.Generator;

namespace SEGate.Logic.Registry
{
	public record BlockId
	{
		public uint StateId { get; set; }
		public BlockId(uint id = 0) => StateId = id;
		public override string ToString() => $"{StateId} {GlobalPalette.GetState(StateId).Name}";
	}
}
