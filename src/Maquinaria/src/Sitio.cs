using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.DbSchema;

namespace  Database.Records  
{
 	[Alias("SITIO")]
	public partial class Sitio{

 		public Sitio(){}

 		[Alias("ID")]
		[Sequence("SITIO_ID_GEN")]
		[PrimaryKey]
		[AutoIncrement]
		[Required]
		public System.Int32 Id { get; set;} 

		[Alias("DESCRIPCION")]
		[Required]
		public System.String Descripcion { get; set;} 

		[Alias("ID_UBICACION")]
		[Required]
		public System.Int32 IdUbicacion { get; set;} 

 	}
 }
