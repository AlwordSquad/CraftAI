using CraftAI.Worker.Logic.Services.Entity.Abstractions;

namespace CraftAI.Worker.Logic.Services.Entity.Model
{
	public record BaseEntity : IEntity
	{
		public int Id { get; set; }
		public float X { get; set; }
		public float Y { get; set; }
		public float Z { get; set; }
	}
}
