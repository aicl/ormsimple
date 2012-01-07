using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.DbSchema;

namespace  Database.Records  
{
 	[Alias("SALARY_HISTORY")]
	public partial class SalaryHistory{

 		public SalaryHistory(){}

 		[Alias("EMP_NO")]
		[PrimaryKey]
		[Required]
		public System.Int16 EmpNo { get; set;} 

		[Alias("CHANGE_DATE")]
		[PrimaryKey]
		[Required]
		public System.DateTime ChangeDate { get; set;} 

		[Alias("UPDATER_ID")]
		[PrimaryKey]
		[Required]
		public System.String UpdaterId { get; set;} 

		[Alias("OLD_SALARY")]
		[Required]
		public System.Decimal OldSalary { get; set;} 

		[Alias("PERCENT_CHANGE")]
		[Required]
		public System.Double PercentChange { get; set;} 

		[Alias("NEW_SALARY")]
		[Compute]
		public System.Double? NewSalary { get; set;} 

 	}
 }
