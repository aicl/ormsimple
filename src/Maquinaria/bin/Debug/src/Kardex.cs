using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;

namespace  Database.Records  
{
 	[Alias("KARDEX")]
	public partial class Kardex{

 		public Kardex(){}

 		[Alias("KARDEXID")]
		[Sequence("KARDEXID_GEN")]
		[PrimaryKey]
		[AutoIncrement]
		[Required]
		public System.Int32 Id { get; set;} 

		[Alias("CODCOMP")]
		[Required]
		public System.String Codcomp { get; set;} 

		[Alias("CODPREFIJO")]
		[Required]
		public System.String Codprefijo { get; set;} 

		[Alias("NUMERO")]
		[Required]
		public System.String Numero { get; set;} 

		[Alias("FECHA")]
		public System.DateTime? Fecha { get; set;} 

		[Alias("FECASENTAD")]
		public System.DateTime? Fecasentad { get; set;} 

		[Alias("OBSERV")]
		public System.String Observ { get; set;} 

		[Alias("PERIODO")]
		public System.String Periodo { get; set;} 

		[Alias("CENID")]
		[Required]
		public System.Int32 Cenid { get; set;} 

		[Alias("AREADID")]
		[Required]
		public System.Int32 Areadid { get; set;} 

		[Alias("SUCID")]
		[Required]
		public System.Int32 Sucid { get; set;} 

		[Alias("CLIENTE")]
		[Required]
		public System.Int32 Cliente { get; set;} 

		[Alias("VENDEDOR")]
		public System.Int32? Vendedor { get; set;} 

		[Alias("FORMAPAGO")]
		public System.String Formapago { get; set;} 

		[Alias("PLAZODIAS")]
		public System.Int16? Plazodias { get; set;} 

		[Alias("BCOID")]
		public System.Int32? Bcoid { get; set;} 

		[Alias("TIPODOC")]
		public System.String Tipodoc { get; set;} 

		[Alias("DOCUMENTO")]
		public System.String Documento { get; set;} 

		[Alias("CONCEPTO")]
		public System.Int32? Concepto { get; set;} 

		[Alias("FECVENCE")]
		public System.DateTime? Fecvence { get; set;} 

		[Alias("RETIVA")]
		public System.Decimal? Retiva { get; set;} 

		[Alias("RETICA")]
		public System.Decimal? Retica { get; set;} 

		[Alias("RETFTE")]
		public System.Decimal? Retfte { get; set;} 

		[Alias("AJUSTEBASE")]
		public System.Double? Ajustebase { get; set;} 

		[Alias("AJUSTEIVA")]
		public System.Double? Ajusteiva { get; set;} 

		[Alias("AJUSTENETO")]
		public System.Double? Ajusteneto { get; set;} 

		[Alias("VRBASE")]
		public System.Double? Vrbase { get; set;} 

		[Alias("VRIVA")]
		public System.Double? Vriva { get; set;} 

		[Alias("VRICONSUMO")]
		public System.Double? Vriconsumo { get; set;} 

		[Alias("VRRFTE")]
		public System.Double? Vrrfte { get; set;} 

		[Alias("VRRICA")]
		public System.Double? Vrrica { get; set;} 

		[Alias("VRRIVA")]
		public System.Double? Vrriva { get; set;} 

		[Alias("TOTAL")]
		public System.Double? Total { get; set;} 

		[Alias("DOCUID")]
		public System.Int32? Docuid { get; set;} 

		[Alias("FPCONTADO")]
		public System.Double? Fpcontado { get; set;} 

		[Alias("FPCREDITO")]
		public System.Double? Fpcredito { get; set;} 

		[Alias("DESPACHAR_A")]
		public System.Int32? DespacharA { get; set;} 

		[Alias("USUARIO")]
		public System.String Usuario { get; set;} 

		[Alias("HORA")]
		public System.String Hora { get; set;} 

		[Alias("FACTORCONV")]
		public System.Decimal? Factorconv { get; set;} 

		[Alias("NROFACPROV")]
		public System.String Nrofacprov { get; set;} 

		[Alias("VEHICULOID")]
		public System.Int32? Vehiculoid { get; set;} 

		[Alias("FECANULADO")]
		public System.DateTime? Fecanulado { get; set;} 

		[Alias("DESXCAMBIO")]
		public System.Double? Desxcambio { get; set;} 

		[Alias("DEVOLXCAMBIO")]
		public System.Int32? Devolxcambio { get; set;} 

		[Alias("TIPOICA2ID")]
		public System.Int32? Tipoica2id { get; set;} 

		[Alias("MONEDA")]
		public System.String Moneda { get; set;} 

		[Alias("NROCONTROL")]
		public System.String Nrocontrol { get; set;} 

		[Alias("PRONTOPAGO")]
		public System.String Prontopago { get; set;} 

		[Alias("MOTIVODEVID")]
		public System.Int32? Motivodevid { get; set;} 

		[Alias("IMPRESA")]
		public System.String Impresa { get; set;} 

		[Alias("HORACREA")]
		public System.String Horacrea { get; set;} 

		[Alias("PUNXVEN")]
		public System.Double? Punxven { get; set;} 

		[Alias("EXPORTACION")]
		public System.String Exportacion { get; set;} 

		[Alias("ANTICIPO")]
		public System.Double? Anticipo { get; set;} 

		[Alias("IMPORTADO")]
		public System.String Importado { get; set;} 

		[Alias("HORACOMANDA")]
		public System.String Horacomanda { get; set;} 

		[Alias("FECEMI")]
		public System.DateTime? Fecemi { get; set;} 

		[Alias("ANTICIPOADIC")]
		public System.Double? Anticipoadic { get; set;} 

		[Alias("RECIBOID")]
		public System.Int32? Reciboid { get; set;} 

		[Alias("IMPNOTENT")]
		public System.String Impnotent { get; set;} 

		[Alias("FECHATERMINACION")]
		public System.DateTime? Fechaterminacion { get; set;} 

		[Alias("FECHARECEPCIONSOLICITADA")]
		public System.DateTime? Fecharecepcionsolicitada { get; set;} 

		[Alias("FECHARECEPCION")]
		public System.DateTime? Fecharecepcion { get; set;} 

		[Alias("IDDIRECCION")]
		public System.Int16? Iddireccion { get; set;} 

		[Alias("HORARECEPCIONSOLICITADA")]
		public System.String Horarecepcionsolicitada { get; set;} 

		[Alias("VRIVAEXC")]
		public System.Double? Vrivaexc { get; set;} 

		[Alias("MOTIVOCIERRE")]
		public System.Int32? Motivocierre { get; set;} 

		[Alias("CONTRATO")]
		public System.String Contrato { get; set;} 

		[Alias("AJUSTEIVAEXC")]
		public System.Double? Ajusteivaexc { get; set;} 

 	}
 }
