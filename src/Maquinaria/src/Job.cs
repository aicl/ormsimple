using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.DbSchema;

namespace  Database.Records  
{
 	[Alias("JOB")]
	public partial class Job{

 		public Job(){}

 		[Alias("JOB_CODE")]
		[PrimaryKey]
		[Required]
		public System.String JobCode { get; set;} 

		[Alias("JOB_GRADE")]
		[PrimaryKey]
		[Required]
		public System.Int16 JobGrade { get; set;} 

		[Alias("JOB_COUNTRY")]
		[PrimaryKey]
		[Required]
		public System.String JobCountry { get; set;} 

		[Alias("JOB_TITLE")]
		[Required]
		public System.String JobTitle { get; set;} 

		[Alias("MIN_SALARY")]
		[Required]
		public System.Decimal MinSalary { get; set;} 

		[Alias("MAX_SALARY")]
		[Required]
		public System.Decimal MaxSalary { get; set;} 

		[Alias("JOB_REQUIREMENT")]
		public System.String JobRequirement { get; set;} 

		[Alias("LANGUAGE_REQ")]
		public System.String LanguageReq { get; set;} 

 	}
 }
