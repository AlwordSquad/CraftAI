using CraftAI.Gate.Logic.Abstractions;
using CraftAI.Gate.Logic.EventHandler;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SEGate.Logic.Tests
{
	public class AgentFixture
	{
		public string Host = "127.0.0.1:25565";
		public string Nick = "AIword";
		public bool RunOnLocal = true;
		public TestCollection TestCollection = new();
		public byte[] ReadBytes(string name)
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			var resourceName = assembly.GetManifestResourceNames()
				.Where(e => e.EndsWith(name))
				.SingleOrDefault();
			using var stream = assembly.GetManifestResourceStream(resourceName);
			using BinaryReader binaryReader = new BinaryReader(stream);
			var bytes = new byte[stream.Length];
			binaryReader.Read(bytes);
			return bytes;
		}
	}

	public class TestCollection : IEventHandlersCollection
	{
		IEventHandler[] IEventHandlersCollection.EventHandlers => new IEventHandler[]
		{
			new KeepAliveEventHandler(),
			// new ChunkDataPacketHandler(),
		};
	}
}
