using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.DbSchema;

namespace  Database.Records  
{
 	[Alias("MI_TABLA")]
	public partial class MiTabla{

 		public MiTabla(){}

 		[Alias("CAMPO1")]
		public System.String Campo1 { get; set;} 

		[Alias("CAMPO2")]
		public System.String Campo2 { get; set;} 

		[Alias("REQUIRE")]
		public System.String Require { get; set;} 

		[Alias("ESTADO")]
		public System.String Estado { get; set;} 

 	}
 }
