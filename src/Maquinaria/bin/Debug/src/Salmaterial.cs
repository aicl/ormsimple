using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;

namespace  Database.Records  
{
 	[Alias("SALMATERIAL")]
	public partial class Salmaterial{

 		public Salmaterial(){}

 		[Alias("MATID")]
		[PrimaryKey]
		[Required]
		public System.Int32 Matid { get; set;} 

		[Alias("BODID")]
		[PrimaryKey]
		[Required]
		public System.Int32 Bodid { get; set;} 

		[Alias("SUCID")]
		[PrimaryKey]
		[Required]
		public System.Int32 Sucid { get; set;} 

		[Alias("EXISTENC")]
		public System.Double? Existenc { get; set;} 

		[Alias("EXISTMIN")]
		public System.Double? Existmin { get; set;} 

		[Alias("EXISTMAX")]
		public System.Double? Existmax { get; set;} 

		[Alias("ENTCAN00")]
		public System.Double? Entcan00 { get; set;} 

		[Alias("ENTVAL00")]
		public System.Double? Entval00 { get; set;} 

		[Alias("SALCAN00")]
		public System.Double? Salcan00 { get; set;} 

		[Alias("SALVAL00")]
		public System.Double? Salval00 { get; set;} 

		[Alias("ENTCAN01")]
		public System.Double? Entcan01 { get; set;} 

		[Alias("ENTVAL01")]
		public System.Double? Entval01 { get; set;} 

		[Alias("SALCAN01")]
		public System.Double? Salcan01 { get; set;} 

		[Alias("SALVAL01")]
		public System.Double? Salval01 { get; set;} 

		[Alias("SANCAN01")]
		public System.Double? Sancan01 { get; set;} 

		[Alias("SANVAL01")]
		public System.Double? Sanval01 { get; set;} 

		[Alias("ENTCAN02")]
		public System.Double? Entcan02 { get; set;} 

		[Alias("ENTVAL02")]
		public System.Double? Entval02 { get; set;} 

		[Alias("SALCAN02")]
		public System.Double? Salcan02 { get; set;} 

		[Alias("SALVAL02")]
		public System.Double? Salval02 { get; set;} 

		[Alias("SANCAN02")]
		public System.Double? Sancan02 { get; set;} 

		[Alias("SANVAL02")]
		public System.Double? Sanval02 { get; set;} 

		[Alias("ENTCAN03")]
		public System.Double? Entcan03 { get; set;} 

		[Alias("ENTVAL03")]
		public System.Double? Entval03 { get; set;} 

		[Alias("SALCAN03")]
		public System.Double? Salcan03 { get; set;} 

		[Alias("SALVAL03")]
		public System.Double? Salval03 { get; set;} 

		[Alias("SANCAN03")]
		public System.Double? Sancan03 { get; set;} 

		[Alias("SANVAL03")]
		public System.Double? Sanval03 { get; set;} 

		[Alias("ENTCAN04")]
		public System.Double? Entcan04 { get; set;} 

		[Alias("ENTVAL04")]
		public System.Double? Entval04 { get; set;} 

		[Alias("SALCAN04")]
		public System.Double? Salcan04 { get; set;} 

		[Alias("SALVAL04")]
		public System.Double? Salval04 { get; set;} 

		[Alias("SANCAN04")]
		public System.Double? Sancan04 { get; set;} 

		[Alias("SANVAL04")]
		public System.Double? Sanval04 { get; set;} 

		[Alias("ENTCAN05")]
		public System.Double? Entcan05 { get; set;} 

		[Alias("ENTVAL05")]
		public System.Double? Entval05 { get; set;} 

		[Alias("SALCAN05")]
		public System.Double? Salcan05 { get; set;} 

		[Alias("SALVAL05")]
		public System.Double? Salval05 { get; set;} 

		[Alias("SANCAN05")]
		public System.Double? Sancan05 { get; set;} 

		[Alias("SANVAL05")]
		public System.Double? Sanval05 { get; set;} 

		[Alias("ENTCAN06")]
		public System.Double? Entcan06 { get; set;} 

		[Alias("ENTVAL06")]
		public System.Double? Entval06 { get; set;} 

		[Alias("SALCAN06")]
		public System.Double? Salcan06 { get; set;} 

		[Alias("SALVAL06")]
		public System.Double? Salval06 { get; set;} 

		[Alias("SANCAN06")]
		public System.Double? Sancan06 { get; set;} 

		[Alias("SANVAL06")]
		public System.Double? Sanval06 { get; set;} 

		[Alias("ENTCAN07")]
		public System.Double? Entcan07 { get; set;} 

		[Alias("ENTVAL07")]
		public System.Double? Entval07 { get; set;} 

		[Alias("SALCAN07")]
		public System.Double? Salcan07 { get; set;} 

		[Alias("SALVAL07")]
		public System.Double? Salval07 { get; set;} 

		[Alias("SANCAN07")]
		public System.Double? Sancan07 { get; set;} 

		[Alias("SANVAL07")]
		public System.Double? Sanval07 { get; set;} 

		[Alias("ENTCAN08")]
		public System.Double? Entcan08 { get; set;} 

		[Alias("ENTVAL08")]
		public System.Double? Entval08 { get; set;} 

		[Alias("SALCAN08")]
		public System.Double? Salcan08 { get; set;} 

		[Alias("SALVAL08")]
		public System.Double? Salval08 { get; set;} 

		[Alias("SANCAN08")]
		public System.Double? Sancan08 { get; set;} 

		[Alias("SANVAL08")]
		public System.Double? Sanval08 { get; set;} 

		[Alias("ENTCAN09")]
		public System.Double? Entcan09 { get; set;} 

		[Alias("ENTVAL09")]
		public System.Double? Entval09 { get; set;} 

		[Alias("SALCAN09")]
		public System.Double? Salcan09 { get; set;} 

		[Alias("SALVAL09")]
		public System.Double? Salval09 { get; set;} 

		[Alias("SANCAN09")]
		public System.Double? Sancan09 { get; set;} 

		[Alias("SANVAL09")]
		public System.Double? Sanval09 { get; set;} 

		[Alias("ENTCAN10")]
		public System.Double? Entcan10 { get; set;} 

		[Alias("ENTVAL10")]
		public System.Double? Entval10 { get; set;} 

		[Alias("SALCAN10")]
		public System.Double? Salcan10 { get; set;} 

		[Alias("SALVAL10")]
		public System.Double? Salval10 { get; set;} 

		[Alias("SANCAN10")]
		public System.Double? Sancan10 { get; set;} 

		[Alias("SANVAL10")]
		public System.Double? Sanval10 { get; set;} 

		[Alias("ENTCAN11")]
		public System.Double? Entcan11 { get; set;} 

		[Alias("ENTVAL11")]
		public System.Double? Entval11 { get; set;} 

		[Alias("SALCAN11")]
		public System.Double? Salcan11 { get; set;} 

		[Alias("SALVAL11")]
		public System.Double? Salval11 { get; set;} 

		[Alias("SANCAN11")]
		public System.Double? Sancan11 { get; set;} 

		[Alias("SANVAL11")]
		public System.Double? Sanval11 { get; set;} 

		[Alias("ENTCAN12")]
		public System.Double? Entcan12 { get; set;} 

		[Alias("ENTVAL12")]
		public System.Double? Entval12 { get; set;} 

		[Alias("SALCAN12")]
		public System.Double? Salcan12 { get; set;} 

		[Alias("SALVAL12")]
		public System.Double? Salval12 { get; set;} 

		[Alias("SANCAN12")]
		public System.Double? Sancan12 { get; set;} 

		[Alias("SANVAL12")]
		public System.Double? Sanval12 { get; set;} 

 	}
 }
