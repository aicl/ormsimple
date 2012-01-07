using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.DbSchema;

namespace  Database.Records  
{
 	[Alias("BIENES")]
	public partial class Bienes{

 		public Bienes(){}

 		[Alias("ID")]
		[Sequence("BIENES_ID_GEN")]
		[PrimaryKey]
		[AutoIncrement]
		[Required]
		public System.Int32 Id { get; set;} 

		[Alias("PLACA")]
		public System.String Placa { get; set;} 

		[Alias("MODELO")]
		[Required]
		public System.String Modelo { get; set;} 

		[Alias("SERIE")]
		[Required]
		public System.String Serie { get; set;} 

		[Alias("IDCATEGORIA")]
		[Required]
		public System.Int32 Idcategoria { get; set;} 

		[Alias("IDESTADO")]
		[Required]
		public System.Int32 Idestado { get; set;} 

		[Alias("IDSITIO")]
		[Required]
		public System.Int32 Idsitio { get; set;} 

		[Alias("IDRESPONSABLE")]
		[Required]
		public System.Int32 Idresponsable { get; set;} 

		[Alias("VALOR")]
		public System.Decimal? Valor { get; set;} 

		[Alias("ACTIVO")]
		[Required]
		public System.Int16 Activo { get; set;} 
		
 	}
 }
