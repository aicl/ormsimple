using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Reflection;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.Common.Utils;
using ServiceStack.OrmSimple.StringExtensions;

namespace ServiceStack.OrmSimple.TypeExtensions
{
	public static partial class Extensions
	{

		internal static string GetColumnNames(this Type tableType)
		{
			var sqlColumns = new StringBuilder();
			tableType.GetModelDefinition().FieldDefinitions
				.ForEach(x => sqlColumns.AppendFormat(
					"{0}\"{1}\" ", sqlColumns.Length > 0 ? "," : "", x.FieldName));

			return sqlColumns.ToString();
		}

				
		public static string ToSelectStatement(this Type tableType)
		{
			return ToSelectStatement(tableType, null);
		}

		public static string ToSelectStatement(this Type tableType, string sqlFilter, params object[] filterParams)
		{
			return Config.DialectProvider.ToSelectStatement(tableType, sqlFilter, filterParams);
		}
		
		public static string ToSelectStatement(this Type fromTableType, Type modelType, string sqlFilter, params object[] filterParams)
			
		{
			return Config.DialectProvider.ToSelectStatement(fromTableType, modelType, sqlFilter, filterParams);
		}
		
		
		public static string ToCreateTableStatement(this Type tableType)
		{
			var sbColumns = new StringBuilder();
			var sbConstraints = new StringBuilder();

			var modelDef = tableType.GetModelDefinition();
			foreach (var fieldDef in modelDef.FieldDefinitions)
			{
				if (sbColumns.Length != 0) sbColumns.Append(", \n  ");

				var columnDefinition = Config.DialectProvider.GetColumnDefinition(
					fieldDef.FieldName,
					fieldDef.FieldType,
					fieldDef.IsPrimaryKey,
					fieldDef.AutoIncrement,
					fieldDef.IsNullable,
					fieldDef.FieldLength,
					fieldDef.DefaultValue);

				sbColumns.Append(columnDefinition);

				if (fieldDef.ReferencesType == null) continue;

				var refModelDef = fieldDef.ReferencesType.GetModelDefinition();
				sbConstraints.AppendFormat(", \n\n  CONSTRAINT \"FK_{0}_{1}\" FOREIGN KEY (\"{2}\") REFERENCES \"{3}\" (\"{4}\")",
					modelDef.ModelName, refModelDef.ModelName, fieldDef.FieldName, refModelDef.ModelName, modelDef.PrimaryKey.FieldName);
			}

			var sql = new StringBuilder(string.Format(
				"CREATE TABLE \"{0}\" \n(\n  {1}{2} \n); \n", modelDef.ModelName, sbColumns, sbConstraints));

			return sql.ToString();
		}

		public static List<string> ToCreateIndexStatements(this Type tableType)
		{
			var sqlIndexes = new List<string>();

			var modelDef = tableType.GetModelDefinition();
			foreach (var fieldDef in modelDef.FieldDefinitions)
			{
				if (!fieldDef.IsIndexed) continue;

				var indexName = GetIndexName(fieldDef.IsUnique, modelDef.ModelName.SafeVarName(), fieldDef.FieldName);

				sqlIndexes.Add(
					ToCreateIndexStatement(fieldDef.IsUnique, indexName, modelDef.ModelName, fieldDef.FieldName));
			}

			foreach (var compositeIndex in modelDef.CompositeIndexes)
			{
				var indexName = GetIndexName(compositeIndex.Unique, modelDef.ModelName.SafeVarName(),
					string.Join("_", compositeIndex.FieldNames.ToArray()));

				var indexNames = string.Join("\" ASC, \"", compositeIndex.FieldNames.ToArray());

				sqlIndexes.Add(
					ToCreateIndexStatement(compositeIndex.Unique, indexName, modelDef.ModelName, indexNames));
			}

			return sqlIndexes;
		}
		
		
		public static ModelDefinition GetModel(this Type modelType){
			return modelType.GetModelDefinition();
		}
		
		
		

		private static string GetIndexName(bool isUnique, string modelName, string fieldName)
		{
			return string.Format("{0}idx_{1}_{2}", isUnique ? "u" : "", modelName, fieldName).ToLower();
		}

		private static string ToCreateIndexStatement(bool isUnique, string indexName, string modelName, string fieldName)
		{
			return string.Format("CREATE {0} INDEX {1} ON \"{2}\" (\"{3}\" ASC); \n",
					isUnique ? "UNIQUE" : "", indexName, modelName, fieldName);
		}
		
		internal static string  GetModelName(this Type tableType){
			return  tableType.GetModelDefinition().ModelName; 
		}
		
		internal static string GetFieldName(this PropertyInfo propertyInfo){
			var alias =  propertyInfo.FirstAttribute<AliasAttribute>();
			return  (alias!=null)? alias.Name: propertyInfo.Name;
		}
		
	}
}