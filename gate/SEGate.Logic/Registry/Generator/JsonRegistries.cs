using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CraftAI.Gate.Logic.Registry.Generator
{
	public class JsonRegistries
	{
		[JsonPropertyName("default")]
		public string Default { get; set; }
		[JsonPropertyName("protocol_id")]
		public int Protocol_id { get; set; }
		[JsonPropertyName("entries")]
		public Dictionary<string, ItemDictionary> Entries { get; set; }
	}

	public class ItemDictionary
	{
		[JsonPropertyName("protocol_id")]
		public int Protocol_id { get; set; }
	}
}
