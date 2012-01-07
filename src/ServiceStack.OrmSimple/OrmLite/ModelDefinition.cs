using System;
using System.Collections.Generic;
using System.Linq;
using ServiceStack.DataAnnotations;

namespace ServiceStack.OrmSimple
{
	public class ModelDefinition
	{
		public ModelDefinition()
		{
			this.FieldDefinitions = new List<FieldDefinition>();
			this.CompositeIndexes = new List<CompositeIndexAttribute>();
		}

		public string Name { get; set; }

		public string Alias { get; set; }

		public string ModelName
		{
			get { return this.Alias ?? this.Name; }
		}

		public Type ModelType { get; set; }

		public FieldDefinition PrimaryKey
		{
			get
			{
				return this.FieldDefinitions.First(x => x.IsPrimaryKey);
			}
		}

		public List<FieldDefinition> FieldDefinitions { get; set; }

		private FieldDefinition[] fieldDefinitionsArray;
		public FieldDefinition[] FieldDefinitionsArray
		{
			get
			{
				if (fieldDefinitionsArray == null)
				{
					fieldDefinitionsArray = FieldDefinitions.ToArray();
				}
				return fieldDefinitionsArray;
			}
		}

		public List<CompositeIndexAttribute> CompositeIndexes { get; set; }
		
		public string FullName{
			get;set;
		}
	}
}