using System.IO;

namespace SEGate.Logic.Registry.Palettes
{
	public interface IPalette
	{
		uint IdForState(BlockState state);
		BlockState StateForId(uint id);
		byte GetBitsPerBlock();
		void Read(Stream data);
		void Write(byte[] data);
	}
}
