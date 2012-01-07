using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;

namespace  Database.Records  
{
 	[Alias("BODEGA")]
	public partial class Bodega{

 		public Bodega(){}

 		[Alias("BODID")]
		[Sequence("BODID_GEN")]
		[PrimaryKey]
		[AutoIncrement]
		[Required]
		public System.Int32 Id { get; set;} 

		[Alias("CODIGO")]
		[Required]
		public System.String Codigo { get; set;} 

		[Alias("NOMBRE")]
		public System.String Nombre { get; set;} 

		[Alias("SUCID")]
		public System.Int32? Sucid { get; set;} 

 	}
 }
