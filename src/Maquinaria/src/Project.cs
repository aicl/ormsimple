using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.DbSchema;

namespace  Database.Records  
{
 	[Alias("PROJECT")]
	public partial class Project{

 		public Project(){}

 		[Alias("PROJ_ID")]
		[PrimaryKey]
		[Required]
		public System.String ProjId { get; set;} 

		[Alias("PROJ_NAME")]
		[Required]
		public System.String ProjName { get; set;} 

		[Alias("PROJ_DESC")]
		public System.String ProjDesc { get; set;} 

		[Alias("TEAM_LEADER")]
		public System.Int16? TeamLeader { get; set;} 

		[Alias("PRODUCT")]
		public System.String Product { get; set;} 

 	}
 }
