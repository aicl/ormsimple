using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.DbSchema;

namespace  Database.Records  
{
 	[Alias("GRUPMAT")]
	public partial class Grupmat{

 		public Grupmat(){}

 		[Alias("GRUPMATID")]
		[Sequence("GRUPMATID_GEN")]
		[PrimaryKey]
		[AutoIncrement]
		[Required]
		public System.Int32 Id { get; set;} 

		[Alias("CODIGO")]
		[Required]
		public System.String Codigo { get; set;} 

		[Alias("DESCRIP")]
		public System.String Descrip { get; set;} 

		[Alias("PORUTIL")]
		public System.Decimal? Porutil { get; set;} 

		[Alias("BONIFICADO")]
		public System.String Bonificado { get; set;} 

		[Alias("PUERTO")]
		public System.String Puerto { get; set;} 

		[Alias("CONSECOMAN")]
		public System.String Consecoman { get; set;} 

		[Alias("INACTIVO")]
		public System.String Inactivo { get; set;} 

		[Alias("OBSERVART")]
		public System.String Observart { get; set;} 

		[Alias("PUERTO2")]
		public System.String Puerto2 { get; set;} 

		[Alias("PROPINART")]
		public System.String Propinart { get; set;} 

		[Alias("EXCLUIDO")]
		public System.String Excluido { get; set;} 

 	}
 }
