using Serilog;

namespace CraftAI.Worker.Logic.Terrain
{
	public class BlockType
	{
		public string blockName { get; set; } = string.Empty;
		public bool isSolid { get; set; }
		public int backFaceTexture { get; set; }
		public int frontFaceTexture { get; set; }
		public int topFaceTexture { get; set; }
		public int bottomFaceTexture { get; set; }
		public int leftFaceTexture { get; set; }
		public int rightFaceTexture { get; set; }

		public int GetTextureID(Face faceIndex) => faceIndex switch
		{
			Face.Back => backFaceTexture,
			Face.Front => frontFaceTexture,
			Face.Top => topFaceTexture,
			Face.Bottom => bottomFaceTexture,
			Face.Left => leftFaceTexture,
			Face.Right => rightFaceTexture,
			_ => Default(faceIndex)
		};

		private int Default(Face index)
		{
			Log.Warning($"Not found face index {index}");
			return backFaceTexture;
		}
	}
}
