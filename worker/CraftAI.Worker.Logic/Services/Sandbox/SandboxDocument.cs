using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CraftAI.Worker.Logic.Services.Sandbox
{
	public class SandboxDocument
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; } = null!;
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
	}
}
