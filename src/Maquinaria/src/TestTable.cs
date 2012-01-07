using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.DbSchema;

namespace  Database.Records  
{
 	[Alias("TEST_TABLE")]
	public partial class TestTable{

 		public TestTable(){}

 		[Alias("ID")]
		[Required]
		public System.Int16 Id { get; set;} 

		[Alias("ID_1")]
		[Required]
		public System.Int16 Id1 { get; set;} 

		[Alias("DESCRIPTION")]
		public System.String Description { get; set;} 

 	}
 }
