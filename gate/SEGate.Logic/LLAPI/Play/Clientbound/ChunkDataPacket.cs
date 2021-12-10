using CraftAI.Gate.Logic.LLAPI.Abstractions;
using CraftAI.Gate.Logic.LLAPI.Attributes;
using NbtLib;

namespace CraftAI.Gate.Logic.LLAPI.Play.Clientbound
{
	public record ChunkDataPacket : IPacketData
	{
		/// <summary>Chunk coordinate (block coordinate divided by 16, rounded down)</summary>
		[LInt] public int ChunkX { get; set; }
		/// <summary>Chunk coordinate (block coordinate divided by 16, rounded down)</summary>
		[LInt] public int ChunkZ { get; set; }
		/// <summary>
		/// BitSet with bits (world height in blocks / 16) set to 1 for every 16×16×16 
		/// chunk section whose data is included in Data. The least significant bit represents 
		/// the chunk section at the bottom of the chunk column (from the lowest y to 15 blocks above)
		/// </summary>
		[LLongArray] public long[] PrimaryBitMask { get; set; }
		/// <summary>
		/// Compound containing one long array named MOTION_BLOCKING,
		/// which is a heightmap for the highest solid block at each position 
		/// in the chunk (as a compacted long array with 256 entries at 9 bits per entry totaling 36 longs). 
		/// The Notchian server also adds a WORLD_SURFACE long array, the purpose of which is unknown, but 
		/// it's not required for the chunk to be accepted.
		/// </summary>
		[LNBT] public NbtCompoundTag Heightmaps { get; set; }
		/// <summary>1024 biome IDs, ordered by x then z then y, in 4×4×4 blocks. See Chunk Format § Biomes.</summary>
		[LVarintArray] public int[] Biomes { get; set; }
		/// <summary>See data structure in Chunk Format</summary>
		[LByteArray] public byte[] Data { get; set; }
		/// <summary>All block entities in the chunk. Use the x, y, and z tags in the NBT to determine their position</summary>
		[LNBTArray] public NbtCompoundTag[] BlockEntities { get; set; }
	}
}
