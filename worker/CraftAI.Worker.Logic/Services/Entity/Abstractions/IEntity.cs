namespace CraftAI.Worker.Logic.Services.Entity.Abstractions
{
	public interface IEntity
	{
		public int Id { get; set; }
		public float X { get; set; }
		public float Y { get; set; }
		public float Z { get; set; }
	}
}
