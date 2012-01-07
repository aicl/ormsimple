using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.DbSchema;

namespace  Database.Records  
{
 	[Alias("PROJ_DEPT_BUDGET")]
	public partial class ProjDeptBudget{

 		public ProjDeptBudget(){}

 		[Alias("FISCAL_YEAR")]
		[PrimaryKey]
		[Required]
		public System.Int32 FiscalYear { get; set;} 

		[Alias("PROJ_ID")]
		[PrimaryKey]
		[Required]
		public System.String ProjId { get; set;} 

		[Alias("DEPT_NO")]
		[PrimaryKey]
		[Required]
		public System.String DeptNo { get; set;} 

		[Alias("QUART_HEAD_CNT")]
		public System.Int32? QuartHeadCnt { get; set;} 

		[Alias("PROJECTED_BUDGET")]
		public System.Decimal? ProjectedBudget { get; set;} 

 	}
 }
