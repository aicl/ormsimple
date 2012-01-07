using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.DbSchema;

namespace  Database.Records  
{
 	[Alias("EMPLOYEE")]
	public partial class Employee{

 		public Employee(){}

 		[Alias("EMP_NO")]
		[Sequence("EMP_NO_GEN")]
		[PrimaryKey]
		[AutoIncrement]
		[Required]
		public System.Int16 Id { get; set;} 

		[Alias("FIRST_NAME")]
		[Required]
		public System.String FirstName { get; set;} 

		[Alias("LAST_NAME")]
		[Required]
		public System.String LastName { get; set;} 

		[Alias("PHONE_EXT")]
		public System.String PhoneExt { get; set;} 

		[Alias("HIRE_DATE")]
		[Required]
		public System.DateTime HireDate { get; set;} 

		[Alias("DEPT_NO")]
		[Required]
		public System.String DeptNo { get; set;} 

		[Alias("JOB_CODE")]
		[Required]
		public System.String JobCode { get; set;} 

		[Alias("JOB_GRADE")]
		[Required]
		public System.Int16 JobGrade { get; set;} 

		[Alias("JOB_COUNTRY")]
		[Required]
		public System.String JobCountry { get; set;} 

		[Alias("SALARY")]
		[Required]
		public System.Decimal Salary { get; set;} 

		[Alias("FULL_NAME")]
		[Compute]
		public System.String FullName { get; set;} 

 	}
 }
