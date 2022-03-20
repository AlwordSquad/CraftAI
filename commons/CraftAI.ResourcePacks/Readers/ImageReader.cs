namespace CraftAI.ResourcePacks.Readers
{
	public class ImageReader : IResourceReader
	{
		private static readonly string pattern = "assets/minecraft/textures/block/";
		private static readonly string ending = ".png";

		public bool IsMatch(string path)
			=> path.Length > pattern.Length + ending.Length && path.StartsWith(pattern) && path.EndsWith(ending);
		public void Read(string name, Stream stream, in ResourcePackJson resourcePack)
			=> resourcePack.TexturesBlock.Add(name, stream);
		public void Finish(ResourcePackJson resourcePack)
			=> resourcePack.TexturesBlock.Save();
	}
}
