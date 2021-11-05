using CraftAI.Worker.Logic.Services.Textures;
using CraftAI.Worker.Logic.Terrain;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CraftAI.Worker.Logic.Services
{
	public interface ITextureService
	{
		public BlockType Get(int id);
	}
	public class JsonTextureService : ITextureService
	{
		public readonly HashSet<string> _transformed = new HashSet<string>();

		public readonly Dictionary<int, BlockType> _textures = new Dictionary<int, BlockType>(1024);
		public JsonTextureService()
		{
			var states = ReadToEnd<Dictionary<string, BlocksModel>>("CraftAI.Worker.Logic.Resources.blocks.json");
			var blocktypes = ReadToEnd<BlockType[]>("CraftAI.Worker.Logic.Resources.BlockTypes.json");
			foreach (var block in blocktypes)
			{
				states.TryGetValue($"minecraft:{block.blockName}", out var model);
				if (model is null || model.States is null) continue;
				var copy = TransformId(block);
				foreach (var state in model.States)
				{
					_textures.Add(state.Id, copy);
				}
			}
			var total = states.Values.SelectMany(e => e.States).Count();
			Log.Information($"Textures initialized {_textures.Count}/{total}");
		}
		public BlockType Get(int id)
		{
			_textures.TryGetValue(id, out var value);
			return value ?? BlockType.Unkwnown;
		}

		protected static T ReadToEnd<T>(string path)
		{
			var assembly = Assembly.GetExecutingAssembly();
			using var stream = assembly.GetManifestResourceStream(path);
			using var reader = new StreamReader(stream ?? throw new ArgumentNullException());
			var text = reader.ReadToEnd();
			return System.Text.Json.JsonSerializer.Deserialize<T>(text) ?? throw new ArgumentNullException(); ;
		}

		private BlockType TransformId(BlockType blockType)
		{
			if (_transformed.Contains(blockType.blockName)) return blockType;

			blockType.bottomFaceTexture = TransformInt(blockType.bottomFaceTexture);
			blockType.frontFaceTexture = TransformInt(blockType.frontFaceTexture);
			blockType.backFaceTexture = TransformInt(blockType.backFaceTexture);
			blockType.topFaceTexture = TransformInt(blockType.topFaceTexture);
			blockType.leftFaceTexture = TransformInt(blockType.leftFaceTexture);
			blockType.rightFaceTexture = TransformInt(blockType.rightFaceTexture);

			_transformed.Add(blockType.blockName);
			return blockType;
			int TransformInt(int id) => id switch
			{
				< 64 => id,
				_ => (((id - 66) / 65) + 1) * 64 + ((id - 66) % 65),
			};

		}
	}
}
