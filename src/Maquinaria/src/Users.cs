using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.DbSchema;

namespace  Database.Records  
{
 	[Alias("USERS")]
	public partial class Users{

 		public Users(){}

 		[Alias("ID")]
		[Sequence("USERS_ID_GEN")]
		[PrimaryKey]
		[AutoIncrement]
		[Required]
		public System.Int16 Id { get; set;} 

		[Alias("NAME")]
		[Required]
		public System.String Name { get; set;} 

		[Alias("PASSWORD")]
		[Required]
		public System.String Password { get; set;} 

		[Alias("FULL_NAME")]
		public System.String FullName { get; set;} 

		[Alias("COL1")]
		[Required]
		public System.String Col1 { get; set;} 

		[Alias("COL2")]
		[Required]
		public System.String Col2 { get; set;} 

		[Alias("COL3")]
		[Required]
		public System.String Col3 { get; set;} 

		[Alias("COL4")]
		public System.Decimal? Col4 { get; set;} 

		[Alias("COL5")]
		public System.Single? Col5 { get; set;} 

		[Alias("COL6")]
		public System.Int32? Col6 { get; set;} 

		[Alias("COL7")]
		public System.Double? Col7 { get; set;} 

		[Alias("COL8")]
		public System.Int64? Col8 { get; set;} 

		[Alias("COL9")]
		public System.DateTime? Col9 { get; set;} 

		[Alias("COL10")]
		public System.DateTime? Col10 { get; set;} 

		[Alias("COL11")]
		public System.Byte? Col11 { get; set;} 

		[Alias("COLNUM")]
		public System.Decimal? Colnum { get; set;} 

		[Alias("COLDECIMAL")]
		public System.Decimal? Coldecimal { get; set;} 

 	}
 }
