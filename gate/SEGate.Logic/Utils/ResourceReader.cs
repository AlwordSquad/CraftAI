using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CraftAI.Gate.Logic.Utils
{
	public static class ResourceReader
	{
		private static readonly Assembly _assembly = Assembly.GetExecutingAssembly();
		public static async Task<string> GetStringAsync(string name)
		{
			var resourceName = _assembly.GetManifestResourceNames().Where(e => e.EndsWith(name)).SingleOrDefault();
			using var stream = _assembly.GetManifestResourceStream(resourceName);
			using StreamReader streamReader = new(stream);
			var stringResult = await streamReader.ReadToEndAsync();
			return stringResult;
		}
	}
}
