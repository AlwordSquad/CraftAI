namespace CraftAI.ResourcePacks.Models
{
	public class BlockJson
	{
		public string? Parent { get; set; }
		public Dictionary<string, string> Textures { get; set; } = new Dictionary<string, string>();
	}
}
