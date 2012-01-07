using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.DbSchema;

namespace  Database.Records  
{
 	[Alias("EMPLOYEE_PROJECT")]
	public partial class EmployeeProject{

 		public EmployeeProject(){}

 		[Alias("EMP_NO")]
		[PrimaryKey]
		[Required]
		public System.Int16 EmpNo { get; set;} 

		[Alias("PROJ_ID")]
		[PrimaryKey]
		[Required]
		public System.String ProjId { get; set;} 

 	}
 }
