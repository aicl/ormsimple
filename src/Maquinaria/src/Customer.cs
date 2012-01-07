using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.DbSchema;

namespace  Database.Records  
{
 	[Alias("CUSTOMER")]
	public partial class Customer{

 		public Customer(){}

 		[Alias("CUST_NO")]
		[Sequence("CUST_NO_GEN")]
		[PrimaryKey]
		[AutoIncrement]
		[Required]
		public System.Int32 Id { get; set;} 

		[Alias("CUSTOMER")]
		[Required]
		public System.String Name { get; set;} 

		[Alias("CONTACT_FIRST")]
		public System.String ContactFirst { get; set;} 

		[Alias("CONTACT_LAST")]
		public System.String ContactLast { get; set;} 

		[Alias("PHONE_NO")]
		public System.String PhoneNo { get; set;} 

		[Alias("ADDRESS_LINE1")]
		public System.String AddressLine1 { get; set;} 

		[Alias("ADDRESS_LINE2")]
		public System.String AddressLine2 { get; set;} 

		[Alias("CITY")]
		public System.String City { get; set;} 

		[Alias("STATE_PROVINCE")]
		public System.String StateProvince { get; set;} 

		[Alias("COUNTRY")]
		public System.String Country { get; set;} 

		[Alias("POSTAL_CODE")]
		public System.String PostalCode { get; set;} 

		[Alias("ON_HOLD")]
		public System.String OnHold { get; set;} 

 	}
 }
