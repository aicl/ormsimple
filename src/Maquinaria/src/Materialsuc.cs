using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;

namespace  Database.Records  
{
 	[Alias("MATERIALSUC")]
	public partial class Materialsuc{

 		public Materialsuc(){}

 		[Alias("MATID")]
		[PrimaryKey]
		[Required]
		public System.Int32 Matid { get; set;} 

		[Alias("SUCID")]
		[PrimaryKey]
		[Required]
		[Ignore]
		public System.Int32 Sucid { get; set;} 
		

		[Alias("EXISTENC")]
		public System.Double? Existenc { get; set;} 

		
 	}
 }
