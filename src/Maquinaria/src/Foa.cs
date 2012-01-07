using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.DbSchema;

namespace  Database.Records  
{
 	[Alias("FOA")]
	public partial class Foa{

 		public Foa(){}

 		[Alias("ID")]
		[Sequence("FOA_ID_GEN")]
		[PrimaryKey]
		[AutoIncrement]
		[Required]
		public System.Int32 Id { get; set;} 

		[Alias("IDBIEN")]
		[Required]
		public System.Int32 Idbien { get; set;} 

		[Alias("NUMERO")]
		[Required]
		public System.String Numero { get; set;} 

 	}
 }
