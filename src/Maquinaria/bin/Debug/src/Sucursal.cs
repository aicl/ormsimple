using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;

namespace  Database.Records  
{
 	[Alias("SUCURSAL")]
	public partial class Sucursal{

 		public Sucursal(){}

 		[Alias("SUCID")]
		[Sequence("SUCID_GEN")]
		[PrimaryKey]
		[AutoIncrement]
		[Required]
		public System.Int32 Id { get; set;} 

		[Alias("CODSUC")]
		public System.String Codsuc { get; set;} 

		[Alias("NOMSUC")]
		public System.String Nomsuc { get; set;} 

		[Alias("DIRECCION")]
		public System.String Direccion { get; set;} 

		[Alias("CIUDAD")]
		public System.String Ciudad { get; set;} 

		[Alias("TELEFONO")]
		public System.String Telefono { get; set;} 

		[Alias("PERBLOQ")]
		public System.String Perbloq { get; set;} 

		[Alias("PERBLOQCAR")]
		public System.String Perbloqcar { get; set;} 

		[Alias("PERBLOQT")]
		public System.String Perbloqt { get; set;} 

		[Alias("PERBLOQINV")]
		public System.String Perbloqinv { get; set;} 

		[Alias("PERBLOQFAC")]
		public System.String Perbloqfac { get; set;} 

		[Alias("PERBLOQR")]
		public System.String Perbloqr { get; set;} 

		[Alias("PREFHOS")]
		public System.String Prefhos { get; set;} 

		[Alias("CTACARINGREC")]
		public System.Int32? Ctacaringrec { get; set;} 

		[Alias("CTACARING")]
		public System.Int32? Ctacaring { get; set;} 

		[Alias("CTACARCTAXCOB")]
		public System.Int32? Ctacarctaxcob { get; set;} 

		[Alias("CTACARREMXFAC")]
		public System.Int32? Ctacarremxfac { get; set;} 

		[Alias("CTACARRETFTE")]
		public System.Int32? Ctacarretfte { get; set;} 

		[Alias("CTACARRETICA")]
		public System.Int32? Ctacarretica { get; set;} 

		[Alias("CTACARDCTO1")]
		public System.Int32? Ctacardcto1 { get; set;} 

		[Alias("CTACARDCTO2")]
		public System.Int32? Ctacardcto2 { get; set;} 

		[Alias("CTACARDCTO3")]
		public System.Int32? Ctacardcto3 { get; set;} 

		[Alias("CTACARDCTO4")]
		public System.Int32? Ctacardcto4 { get; set;} 

		[Alias("CTACARANTICIPO")]
		public System.Int32? Ctacaranticipo { get; set;} 

		[Alias("CTACOSTOS")]
		public System.Int32? Ctacostos { get; set;} 

		[Alias("CIUDANEID")]
		public System.Int32? Ciudaneid { get; set;} 

		[Alias("CODOPEEMP")]
		public System.String Codopeemp { get; set;} 

		[Alias("CONCEPTOFAC")]
		public System.Int32? Conceptofac { get; set;} 

		[Alias("CONCEPTOMAN")]
		public System.Int32? Conceptoman { get; set;} 

		[Alias("CONCEPTORFTE")]
		public System.Int32? Conceptorfte { get; set;} 

		[Alias("CONCEPTORICA")]
		public System.Int32? Conceptorica { get; set;} 

		[Alias("CONCEPTODCTO1")]
		public System.Int32? Conceptodcto1 { get; set;} 

		[Alias("CONCEPTODCTO2")]
		public System.Int32? Conceptodcto2 { get; set;} 

		[Alias("CONCEPTODCTO3")]
		public System.Int32? Conceptodcto3 { get; set;} 

		[Alias("CONCEPTODCTO4")]
		public System.Int32? Conceptodcto4 { get; set;} 

		[Alias("CTACARRETEIVA")]
		public System.Int32? Ctacarreteiva { get; set;} 

		[Alias("NUMRESOLUCION")]
		public System.String Numresolucion { get; set;} 

		[Alias("PERBLOQCARFIN")]
		public System.String Perbloqcarfin { get; set;} 

		[Alias("ZONA")]
		public System.String Zona { get; set;} 

		[Alias("CTACARDCTO5")]
		public System.Int32? Ctacardcto5 { get; set;} 

		[Alias("CTACARDCTO6")]
		public System.Int32? Ctacardcto6 { get; set;} 

		[Alias("CONCEPTODCTO5")]
		public System.Int32? Conceptodcto5 { get; set;} 

		[Alias("CONCEPTODCTO6")]
		public System.Int32? Conceptodcto6 { get; set;} 

 	}
 }
