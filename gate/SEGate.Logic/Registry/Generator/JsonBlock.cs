using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SEGate.Logic.Registry.Generator
{
	public class GeneratedBlock
	{
		[JsonPropertyName("states")]
		public List<GeneratedState> States { get; set; }
		public class GeneratedState
		{
			[JsonPropertyName("id")]
			public uint Id { get; set; }
			[JsonPropertyName("default")]
			public bool Default { get; set; }
		}
	}
}
