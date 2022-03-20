using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

#pragma warning disable CA1416 // Проверка совместимости платформы
namespace CraftAI.ResourcePacks.Models
{
	public class TexturePack
	{
		public int Width { get; } = 512;
		public int Height { get; } = 1024 + 1024;
		public int XPoint { get; private set; }
		public int YPoint { get; private set; }
		public int MaxHeight { get; private set; }
		private Bitmap? Map;
		private Dictionary<string, Bitmap> Images = new Dictionary<string, Bitmap>();
		public TexturePack()
		{
			Map = new Bitmap(Width, Height);
		}
		public void Add(string name, Stream stream)
		{
			var item = new Bitmap(stream);
			Images[name.Replace(".png", "")] = item;
			if (item.Height > 16) return;


		}
		public void Save()
		{
			if (Map is null) return;
			Dictionary<string, PointSize> coordinates = new Dictionary<string, PointSize>();
			foreach (var pair in Images.OrderBy(e => e.Value.Height))
			{
				var name = pair.Key;
				var image = pair.Value;
				using (image)
				{
					if (XPoint + image.Width > Width)
					{
						XPoint = 0;
						YPoint += MaxHeight;
						MaxHeight = 0;
					}

					coordinates[name] = new PointSize()
					{
						X = XPoint,
						Y = YPoint,
						Height = image.Height,
						Width = image.Width,
					};

					using (var g = Graphics.FromImage(Map))
					{
						g.DrawImage(image, XPoint, YPoint, image.Width, image.Height);
					}
					MaxHeight = Math.Max(image.Height, MaxHeight);
					XPoint += image.Width;
				}
			}
			Images.Clear();
			Map.Save(@"C:\opt\craft-ai\atlas.png", ImageFormat.Png);
			Map.Dispose();
			Map = null;

			var atalasJson = System.Text.Json.JsonSerializer.Serialize(coordinates);
			File.WriteAllText(@"C:\opt\craft-ai\atlas.json", atalasJson);

			var classCode = GenerateClass(coordinates);
			File.WriteAllText(@"C:\opt\craft-ai\AtlasDictionary.cs", classCode);

		}

		private string GenerateClass(Dictionary<string, PointSize> data)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(
@"
using System.Collections.Generic;

namespace Assets.Code.Resources
{
	public partial class AtlasDictionary
	{
		private struct PointSize
		{
			public int X { get; set; }
			public int Y { get; set; }
			public int Width { get; set; }
			public int Height { get; set; }
			public PointSize(int x, int y, int width, int height)
			{
				X = x;
				Y = y;
				Width = width;
				Height = height;
			}
		}
		private static readonly IReadOnlyDictionary<string, PointSize> _map
			= new Dictionary<string, PointSize>
			{"
			);

			foreach (var pair in data)
			{
				stringBuilder.AppendLine(
					$"{{ \"{pair.Key}\",new PointSize({pair.Value.X}, {pair.Value.Y}, {pair.Value.Width}, {pair.Value.Height}) }},"
				);
			}


			stringBuilder.AppendLine(
				@"
			};
	}
}"
			);

			return stringBuilder.ToString();
		}
	}
}
#pragma warning restore CA1416 // Проверка совместимости платформы