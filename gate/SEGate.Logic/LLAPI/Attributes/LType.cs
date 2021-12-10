using System;
using System.IO;

namespace CraftAI.Gate.Logic.LLAPI.Attributes
{
	/// <summary>low level minecraft network type</summary>
	public abstract class LType : Attribute
	{
		public abstract void Write(dynamic value, Stream stream);
		public abstract dynamic Read(Stream stream);
	}
}
