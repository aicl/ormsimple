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
		public System.Int32 Sucid { get; set;} 

		[Alias("FECACT")]
		public System.DateTime? Fecact { get; set;} 

		[Alias("EXISTENC")]
		public System.Double? Existenc { get; set;} 

		[Alias("EXISTMIN")]
		public System.Double? Existmin { get; set;} 

		[Alias("EXISTMAX")]
		public System.Double? Existmax { get; set;} 

		[Alias("COSTO")]
		public System.Double? Costo { get; set;} 

		[Alias("PORCUTILD")]
		public System.Decimal? Porcutild { get; set;} 

		[Alias("PORCUTILM")]
		public System.Decimal? Porcutilm { get; set;} 

		[Alias("OBSERV")]
		public System.String Observ { get; set;} 

		[Alias("IMPCONS")]
		public System.Decimal? Impcons { get; set;} 

		[Alias("COSTESTPRD")]
		public System.Double? Costestprd { get; set;} 

		[Alias("FECULTCLI")]
		public System.DateTime? Fecultcli { get; set;} 

		[Alias("ULTCLI")]
		public System.Int32? Ultcli { get; set;} 

		[Alias("PRECULTCLI")]
		public System.Double? Precultcli { get; set;} 

		[Alias("CANULTCLI")]
		public System.Double? Canultcli { get; set;} 

		[Alias("FECULTPROV")]
		public System.DateTime? Fecultprov { get; set;} 

		[Alias("ULTPRO")]
		public System.Int32? Ultpro { get; set;} 

		[Alias("PRECULTPROV")]
		public System.Double? Precultprov { get; set;} 

		[Alias("CANULTPROV")]
		public System.Double? Canultprov { get; set;} 

		[Alias("PRECIO1")]
		public System.Double? Precio1 { get; set;} 

		[Alias("PRECIO2")]
		public System.Double? Precio2 { get; set;} 

		[Alias("PRECIO3")]
		public System.Double? Precio3 { get; set;} 

		[Alias("PRECIO4")]
		public System.Double? Precio4 { get; set;} 

		[Alias("PRECIO5")]
		public System.Double? Precio5 { get; set;} 

		[Alias("DESCUENTO1")]
		public System.Int16? Descuento1 { get; set;} 

		[Alias("DESCUENTO2")]
		public System.Int16? Descuento2 { get; set;} 

		[Alias("DESCUENTO3")]
		public System.Int16? Descuento3 { get; set;} 

		[Alias("DESCUENTO4")]
		public System.Int16? Descuento4 { get; set;} 

		[Alias("DESCUENTO5")]
		public System.Int16? Descuento5 { get; set;} 

		[Alias("PRECIOM1")]
		public System.Double? Preciom1 { get; set;} 

		[Alias("PRECIOM2")]
		public System.Double? Preciom2 { get; set;} 

		[Alias("PRECIOM3")]
		public System.Double? Preciom3 { get; set;} 

		[Alias("PRECIOM4")]
		public System.Double? Preciom4 { get; set;} 

		[Alias("PRECIOM5")]
		public System.Double? Preciom5 { get; set;} 

		[Alias("ESCALAMIN1")]
		public System.Double? Escalamin1 { get; set;} 

		[Alias("ESCALAMIN2")]
		public System.Double? Escalamin2 { get; set;} 

		[Alias("ESCALAMIN3")]
		public System.Double? Escalamin3 { get; set;} 

		[Alias("ESCALAMIN4")]
		public System.Double? Escalamin4 { get; set;} 

		[Alias("ESCALAMIN5")]
		public System.Double? Escalamin5 { get; set;} 

		[Alias("FECDESINI")]
		public System.DateTime? Fecdesini { get; set;} 

		[Alias("FECDESFIN")]
		public System.DateTime? Fecdesfin { get; set;} 

		[Alias("FACTOR1")]
		public System.Decimal? Factor1 { get; set;} 

		[Alias("FACTOR2")]
		public System.Decimal? Factor2 { get; set;} 

		[Alias("FACTOR3")]
		public System.Decimal? Factor3 { get; set;} 

		[Alias("FACTOR4")]
		public System.Decimal? Factor4 { get; set;} 

		[Alias("FACTOR5")]
		public System.Decimal? Factor5 { get; set;} 

		[Alias("INACTIVO")]
		public System.String Inactivo { get; set;} 

		[Alias("POS_REDIME")]
		public System.String PosRedime { get; set;} 

		[Alias("POS_FACPTO")]
		public System.Int16? PosFacpto { get; set;} 

		[Alias("DOCULTPROV")]
		public System.String Docultprov { get; set;} 

		[Alias("DOCULTCLI")]
		public System.String Docultcli { get; set;} 

		[Alias("ULTCOSTPROM")]
		public System.Double? Ultcostprom { get; set;} 

		[Alias("COSTOPRES")]
		public System.Double? Costopres { get; set;} 

		[Alias("UBICACION")]
		public System.String Ubicacion { get; set;} 

		[Alias("CANT30")]
		public System.Double? Cant30 { get; set;} 

		[Alias("CANT60")]
		public System.Double? Cant60 { get; set;} 

		[Alias("CANT90")]
		public System.Double? Cant90 { get; set;} 

		[Alias("CANT120")]
		public System.Double? Cant120 { get; set;} 

		[Alias("CANTMAS")]
		public System.Double? Cantmas { get; set;} 

		[Alias("PORCOSIND")]
		public System.Decimal? Porcosind { get; set;} 

 	}
 }
