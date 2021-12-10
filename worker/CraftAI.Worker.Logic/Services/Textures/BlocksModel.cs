using System;
using System.Text.Json.Serialization;

namespace CraftAI.Worker.Logic.Services.Textures
{
	public class State
	{
		[JsonPropertyName("id")] public int Id { get; set; } = 0;
		[JsonPropertyName("default")] public bool Default { get; set; } = false;
	}
	public class BlocksModel
	{
		[JsonPropertyName("states")] public State[] States { get; set; } = Array.Empty<State>();
	}
}
