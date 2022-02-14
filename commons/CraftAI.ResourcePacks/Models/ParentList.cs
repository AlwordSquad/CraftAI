namespace CraftAI.ResourcePacks.Models
{
	public class ParentList<T>
	{
		public ParentList<T>? Parent { get; set; }
		public T Value { get; }
		public ParentList(T value)
		{
			Value = value;
		}
		public override string? ToString() => Value?.ToString() ?? base.ToString();
	}
}
