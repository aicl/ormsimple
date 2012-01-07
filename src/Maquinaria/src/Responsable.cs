using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.DbSchema;

namespace  Database.Records  
{
 	[Alias("RESPONSABLE")]
	public partial class Responsable{

 		public Responsable(){}

 		[Alias("ID")]
		[Sequence("RESPONSABLE_ID_GEN")]
		[PrimaryKey]
		[AutoIncrement]
		[Required]
		public System.Int32 Id { get; set;} 

		[Alias("NOMBRE")]
		[Required]
		public System.String Nombre { get; set;} 

		[Alias("TELEFONO")]
		[Required]
		public System.String Telefono { get; set;} 

 	}
 }
