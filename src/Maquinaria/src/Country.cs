using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.DbSchema;

namespace  Database.Records  
{
 	[Alias("COUNTRY")]
	public partial class Country{

 		public Country(){}

 		[Alias("COUNTRY")]
		[PrimaryKey]
		[Required]
		public System.String Name { get; set;} 

		[Alias("CURRENCY")]
		[Required]
		public System.String Currency { get; set;} 

 	}
 }
