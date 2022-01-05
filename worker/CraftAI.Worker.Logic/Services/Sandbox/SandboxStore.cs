using AutoMapper;
using Craft.AI.Worker.Interface.Network.Clientbound;
using Craft.AI.Worker.Interface.Network.Serverbound;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CraftAI.Worker.Logic.Services.Sandbox
{
	public interface ISandboxStore
	{
		Task<string> AddSandbox(CreateSandboxRequest createSandboxRequest);
		Task Remove(string id);
		Task<SandboxItem[]> GetAll(CreateSandboxRequest createSandboxRequest);
	}
	public class SandboxStore : ISandboxStore
	{
		private readonly IMongoCollection<SandboxDocument> _books;
		private readonly IMapper _mapper;
		public SandboxStore(IConfiguration configuration, IMapper mapper)
		{
			MongoClient client = new(configuration.GetConnectionString("MongoDB"));
			IMongoDatabase database = client.GetDatabase("Worker");
			_books = database.GetCollection<SandboxDocument>("SandboxDocuments");
			var indexKeysDefinition = Builders<SandboxDocument>.IndexKeys.Ascending(chunk => chunk.Id);
			_books.Indexes.CreateOneAsync(new CreateIndexModel<SandboxDocument>(indexKeysDefinition));
			_mapper = mapper;
		}

		public async Task<string> AddSandbox(CreateSandboxRequest createSandboxRequest)
		{
			var sandboxs = _mapper.Map<SandboxDocument>(createSandboxRequest);
			await _books.InsertOneAsync(sandboxs);
			return sandboxs.Id;
		}

		public async Task<SandboxItem[]> GetAll(CreateSandboxRequest createSandboxRequest)
		{
			var documents = await _books.Find(book => true).ToListAsync();
			var sandboxs = _mapper.Map<SandboxItem[]>(documents);
			return sandboxs?.Where(e => e is not null).ToArray() ?? Array.Empty<SandboxItem>();
		}

		public Task Remove(string id) =>
		   _books.DeleteOneAsync(sandbox => sandbox.Id == id);
	}
}
