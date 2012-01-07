using System;

namespace ServiceStack.DataAnnotations
{
	[AttributeUsage( AttributeTargets.Property)]
	public class SequenceAttribute : Attribute
	{
		public string Name { get; set; }

		public SequenceAttribute(string name)
		{
			this.Name = name;
		}
	}
}