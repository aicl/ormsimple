using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.DbSchema;

namespace  Database.Records  
{
 	[Alias("MATERIAL")]
	public partial class Material{

 		public Material(){}

 		[Alias("MATID")]
		[Sequence("MATID_GEN")]
		[PrimaryKey]
		[AutoIncrement]
		[Required]
		public System.Int32 Id { get; set;} 

		[Alias("CODIGO")]
		[Required]
		public System.String Codigo { get; set;} 

		[Alias("CODBARRA")]
		public System.String Codbarra { get; set;} 

		[Alias("DESCRIP")]
		public System.String Descrip { get; set;} 

		[Alias("GRUPMATID")]
		public System.Int32? Grupmatid { get; set;} 

		[Alias("REFERENCIA")]
		public System.String Referencia { get; set;} 

		[Alias("PESO")]
		public System.Decimal? Peso { get; set;} 

		[Alias("UNIDAD")]
		public System.String Unidad { get; set;} 

		[Alias("UNIMAY")]
		public System.String Unimay { get; set;} 

		[Alias("GCMATID")]
		public System.Int32? Gcmatid { get; set;} 

		[Alias("TIPOIVAID")]
		[Required]
		public System.Int32 Tipoivaid { get; set;} 

		[Alias("FACTOR")]
		public System.Decimal? Factor { get; set;} 

		[Alias("FACTORGLB")]
		public System.Decimal? Factorglb { get; set;} 

		[Alias("COMISION")]
		public System.Double? Comision { get; set;} 

		[Alias("LINEAMATID")]
		public System.Int32? Lineamatid { get; set;} 

		[Alias("TIPMAT")]
		public System.String Tipmat { get; set;} 

		[Alias("TIPSERIAL")]
		public System.String Tipserial { get; set;} 

		[Alias("RUTAFOTO")]
		public System.String Rutafoto { get; set;} 

		[Alias("HORASSERV")]
		public System.Int16? Horasserv { get; set;} 

		[Alias("PORUTIL")]
		public System.Decimal? Porutil { get; set;} 

		[Alias("PORCOMISION")]
		public System.Decimal? Porcomision { get; set;} 

		[Alias("EXCLUIDO")]
		public System.String Excluido { get; set;} 

		[Alias("APROXIMA")]
		public System.String Aproxima { get; set;} 

		[Alias("REFRIGERADO")]
		public System.String Refrigerado { get; set;} 

		[Alias("IDSUBGRUPOSICO")]
		public System.Int32? Idsubgruposico { get; set;} 

		[Alias("SW")]
		public System.String Sw { get; set;} 

 	}
 }
