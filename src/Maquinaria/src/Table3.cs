using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.DbSchema;

namespace  Database.Records  
{
 	[Alias("TABLE3")]
	public partial class Table3{

 		public Table3(){}

 		[Alias("CAMPO1")]
		public System.String Campo1 { get; set;} 

		[Alias("CAMPO2")]
		public System.String Campo2 { get; set;} 

 	}
 }
