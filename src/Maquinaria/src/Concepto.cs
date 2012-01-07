using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;

namespace  Database.Records  
{
 	[Alias("CONCEPTO")]
	public partial class Concepto{

 		public Concepto(){}

 		[Alias("CONCID")]
		[Sequence("CONCID_GEN")]
		[PrimaryKey]
		[AutoIncrement]
		[Required]
		public System.Int32 Id { get; set;} 

		[Alias("CODIGO")]
		[Required]
		public System.String Codigo { get; set;} 

		[Alias("TIPOIE")]
		[Required]
		public System.String Tipoie { get; set;} 

		[Alias("DESCRIP")]
		public System.String Descrip { get; set;} 

		[Alias("CTAVAL")]
		public System.Int32? Ctaval { get; set;} 

		[Alias("CTAINT")]
		public System.Int32? Ctaint { get; set;} 

		[Alias("CTAMOR")]
		public System.Int32? Ctamor { get; set;} 

		[Alias("PORCIVA")]
		public System.Int16? Porciva { get; set;} 

		[Alias("PORINTMORA")]
		public System.Int16? Porintmora { get; set;} 

		[Alias("CONVACT")]
		public System.String Convact { get; set;} 

		[Alias("IVA")]
		public System.Int32? Iva { get; set;} 

		[Alias("TIPOTRANS")]
		public System.String Tipotrans { get; set;} 

		[Alias("CTAORDEN")]
		public System.Int32? Ctaorden { get; set;} 

		[Alias("EXCLUIRM")]
		public System.String Excluirm { get; set;} 

		[Alias("RETTIPO")]
		public System.String Rettipo { get; set;} 

		[Alias("RUBRO")]
		public System.String Rubro { get; set;} 

		[Alias("CTAACREE")]
		public System.Int32? Ctaacree { get; set;} 

 	}
 }
