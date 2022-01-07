using CraftAI.Worker.Logic.Services.Entity.Abstractions;
using CraftAI.Worker.Logic.Services.Items;

namespace CraftAI.Worker.Logic.Services.Agent
{
	public interface IAgent : IEntity
	{
		public int Health { get; }
		public int Starvation { get; }
		public int Experience { get; }
	}
	public class AgentEntity : IAgent
	{
		public string UUID { get; set; } = string.Empty;
		public int Id { get; set; }
		public float X { get; set; }
		public float Y { get; set; }
		public float Z { get; set; }
		public int Health { get; set; }
		public int Starvation { get; set; }
		public int Experience { get; set; }
		public Inventory Inventory { get; set; } = new Inventory();
	}
}
