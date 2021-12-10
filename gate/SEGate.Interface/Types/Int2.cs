namespace CraftAI.Gate.Interface.Types
{
	public record Int2
	{
		public int X { get; set; }
		public int Z { get; set; }

		public Int2() { }
		public Int2(int x, int z) => (X, Z) = (x, z);
	}
}
