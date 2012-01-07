using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.DbSchema;

namespace  Database.Records  
{
 	[Alias("UBICACION")]
	public partial class Ubicacion{

 		public Ubicacion(){}

 		[Alias("ID")]
		[Sequence("UBICACION_ID_GEN")]
		[PrimaryKey]
		[AutoIncrement]
		[Required]
		public System.Int32 Id { get; set;} 

		[Alias("DESCRIPCION")]
		[Required]
		public System.String Descripcion { get; set;} 

 	}
 }
