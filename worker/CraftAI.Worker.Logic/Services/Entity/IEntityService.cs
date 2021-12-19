using CraftAI.Worker.Logic.Services.Entity.Abstractions;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.Services.Entity
{
	/// <summary>
	/// Entity service.
	/// Update range can be per server/world/chunks depend on realization
	/// </summary>
	public interface IEntityService
	{
		/// <summary>Add/Set entity position</summary>
		ValueTask Update(params IEntity[] entity);
		/// <summary>Remove entity</summary>
		ValueTask Delete(params int[] entity);
		/// <summary>Get entire state</summary>
		ValueTask<IEntity[]> State();
		/// <summary>Get changes since last changes request</summary>
		ValueTask<IEntity[]> Changes();
	}
}
