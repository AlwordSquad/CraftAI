using SEGate.Logic.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEGate.Logic.Registry.Generator
{
	public class RegistriesPalette
	{
		private readonly Dictionary<string, JsonRegistries> Registres;
		public RegistriesPalette()
		{
			string json = ResourceReader.GetStringAsync("registries.json").GetAwaiter().GetResult();
			Registres = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, JsonRegistries>>(json);
		}

		/// <summary>
		/// https://wiki.vg/Protocol
		/// java -cp minecraft_server.jar net.minecraft.data.Main --reports
		/// </summary>
		public void GenerateScript()
		{
			string key = "minecraft:";
			var intms = Registres["minecraft:item"].Entries.Count;

			StringBuilder codegenerator = new StringBuilder();
			foreach (var entity in Registres["minecraft:item"].Entries)
			{
				codegenerator.AppendLine($"{entity.Key.Substring(entity.Key.IndexOf(key) + key.Length)} = {entity.Value.Protocol_id},");
			}
			File.AppendAllText($"{Environment.CurrentDirectory}\\generatedItems.txt", codegenerator.ToString());
		}
	}
}
