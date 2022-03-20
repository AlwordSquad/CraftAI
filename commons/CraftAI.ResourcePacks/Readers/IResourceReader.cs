namespace CraftAI.ResourcePacks.Readers
{
	public interface IResourceReader
	{
		bool IsMatch(string path);
		void Read(string name, Stream stream, in ResourcePackJson resourcePack);
		void Finish(ResourcePackJson resourcePack);
	}
}
