using CraftAI.ResourcePacks.Readers;
using System.IO.Compression;

namespace CraftAI.ResourcePacks.Utils
{
	public class ResourcePackReader
	{
		private static readonly IReadOnlyCollection<IResourceReader> _readers = new List<IResourceReader>
		{
			new BlockModelsReader()
		};

		public static ResourcePackJson FromDefaults()
		{
			using var stream = DefaultResourcePackStream();
			return From(stream);
		}
		public static ResourcePackJson From(Stream stream)
		{
			var resourcePack = new ResourcePackJson();
			using var zip = new ZipArchive(stream);
			foreach (var entity in zip.Entries)
			{
				foreach (var reader in _readers)
				{
					if (!reader.IsMatch(entity.FullName)) continue;
					using var entityStream = entity.Open();
					reader.Read(entity.Name, entityStream, resourcePack);
				}
			}
			return resourcePack;
		}

		private static Stream DefaultResourcePackStream()
		{
			var currentPath = Directory.GetCurrentDirectory();
			var packPath = Path.Combine(currentPath, Constants.Resources.PacksDefault);
			return File.OpenRead(packPath);
		}
	}
}
