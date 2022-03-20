using Craft.AI.Worker.Interface;
using MediatR;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.Services.TerrainRender.Model
{
	public interface ITerrainRender
	{
		public Task SetChunk();
		public Task SetBlock();
		public Task GetRender(int x, int y);
		public ValueTask Subscribe(IWeb web, int x, int y);
		public ValueTask Usubscribe(IWeb web);
		public ValueTask Usubscribe(IWeb web, int x, int y);
	}
	public class RegionRender : ITerrainRender
	{
		private readonly IMediator _mediator;
		public RegionRender(IMediator mediator) => _mediator = mediator;
		public Task GetRender(int x, int y)
		{
			throw new System.NotImplementedException();
		}

		public Task SetBlock()
		{
			throw new System.NotImplementedException();
		}

		public Task SetChunk()
		{
			throw new System.NotImplementedException();
		}

		public ValueTask Subscribe(IWeb web, int x, int y)
		{
			throw new System.NotImplementedException();
		}

		public ValueTask Usubscribe(IWeb web)
		{
			throw new System.NotImplementedException();
		}

		public ValueTask Usubscribe(IWeb web, int x, int y)
		{
			throw new System.NotImplementedException();
		}
	}
}
