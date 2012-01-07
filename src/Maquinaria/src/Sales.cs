using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.DbSchema;

namespace  Database.Records  
{
 	[Alias("SALES")]
	public partial class Sales{

 		public Sales(){}

 		[Alias("PO_NUMBER")]
		[PrimaryKey]
		[Required]
		
		public System.String PoNumber { get; set;} 

		[Alias("CUST_NO")]
		[References(typeof(Customer))]
		[Required]
		public System.Int32 CustNo { get; set;} 

		[Alias("SALES_REP")]
		public System.Int16? SalesRep { get; set;} 

		[Alias("ORDER_STATUS")]
		[Required]
		public System.String OrderStatus { get; set;} 

		[Alias("ORDER_DATE")]
		[Required]
		public System.DateTime OrderDate { get; set;} 

		[Alias("SHIP_DATE")]
		public System.DateTime? ShipDate { get; set;} 

		[Alias("DATE_NEEDED")]
		public System.DateTime? DateNeeded { get; set;} 

		[Alias("PAID")]
		public System.String Paid { get; set;} 

		[Alias("QTY_ORDERED")]
		[Required]
		public System.Int32 QtyOrdered { get; set;} 

		[Alias("TOTAL_VALUE")]
		[Required]
		public System.Decimal TotalValue { get; set;} 

		[Alias("DISCOUNT")]
		[Required]
		public System.Single Discount { get; set;} 

		[Alias("ITEM_TYPE")]
		public System.String ItemType { get; set;} 

		[Alias("AGED")]
		[Compute]
		public System.Decimal? Aged { get; set;} 

 	}
 }
