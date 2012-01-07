using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.DbSchema;

namespace  Database.Records  
{
 	[Alias("COMPANY")]
	public partial class Company{

 		public Company(){}

 		[Alias("ID")]
		[Sequence("COMPANY_ID_GEN")]
		[PrimaryKey]
		[AutoIncrement]
		[Required]
		public System.Int32 Id { get; set;} 

		[Alias("NAME")]
		public System.String Name { get; set;} 

		[Alias("TURNOVER")]
		public System.Single? Turnover { get; set;} 

		[Alias("STARTED")]
		public System.DateTime? Started { get; set;} 

		[Alias("EMPLOYEES")]
		public System.Int32? Employees { get; set;} 

		[Alias("CREATED_DATE")]
		public System.DateTime? CreatedDate { get; set;} 

 	}
 }
