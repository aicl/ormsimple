using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.DbSchema;

namespace  Database.Records  
{
 	[Alias("DEPARTMENT")]
	public partial class Department{

 		public Department(){}

 		[Alias("DEPT_NO")]
		[PrimaryKey]
		[Required]
		public System.String Id { get; set;} 

		[Alias("DEPARTMENT")]
		[Required]
		public System.String Name { get; set;} 

		[Alias("HEAD_DEPT")]
		public System.String HeadDept { get; set;} 

		[Alias("MNGR_NO")]
		public System.Int16? MngrNo { get; set;} 

		[Alias("BUDGET")]
		public System.Decimal? Budget { get; set;} 

		[Alias("LOCATION")]
		public System.String Location { get; set;} 

		[Alias("PHONE_NO")]
		public System.String PhoneNo { get; set;} 

 	}
 }
