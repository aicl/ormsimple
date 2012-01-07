using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Data;

using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.Common.Extensions;
using System.Reflection;

using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.TypeExtensions;
using ServiceStack.OrmSimple.ObjectExtensions;
using ServiceStack.OrmSimple.Firebird;

namespace TestSimpleFirebird01
{
	
	[Alias("USERS")]
	public  class User
	{
		
		[Alias("ID")]
		[Sequence("USERS_ID_GEN")]
		public int Id { get; set; }
		[Alias("NAME")]
    	public string Name { get; set; }
		[Alias("PASSWORD")]
    	public string Password { get; set; }
		[Alias("COL1")]
    	public string Col1 { get; set; }
		[Alias("COL2")]
		public string Col2 { get; set; }
		[Alias("COL3")]
		public string Col3 { get; set; }
		
		[Alias("ACTIVEINTEGER")]
		public bool Active { get; set; }
		
		[Alias("ACTIVECHAR")]
		public bool Active2 { get; set; }
		
		[Ignore]
		public string SomeStringProperty { 
			get{ return "SomeValue No from dB!!!";}
		}
		
		[Ignore]
		public Int32 SomeInt32Property { 
			get{ return 35;}
		}
		
		[Ignore]
		public DateTime SomeDateTimeProperty { 
			get{ return DateTime.Now ;}
		}
		
		[Ignore]
		public Int32? SomeInt32NullableProperty { 
			get{ return null;}
		}
		
		[Ignore]
		public DateTime? SomeDateTimeNullableProperty { 
			get{ return null ;}
		}
		
		
		
	}
	
	class MainClass
	{
		public static void Main (string[] args)
		{
			
			User us = new User();
			
			/*
			object[] md = us.GetType().GetCustomAttributes(typeof(AliasAttribute),true);
			if(md!=null){
				foreach(var o in md){
					
					Console.WriteLine("Atributo {0}", (o as AliasAttribute).Name );
				}
			}
			
			Console.WriteLine(us.GetType().FirstAttribute<AliasAttribute>().Name);
			
			var objProperties = us.GetType().GetProperties(
						BindingFlags.Public | BindingFlags.Instance).ToList<PropertyInfo>();
			
			foreach(var pi in objProperties){
				
				Console.WriteLine( "Name : {0},  Alias {1}", pi.Name , pi.FirstAttribute<AliasAttribute>().Name);
				if(pi.Name=="Name") 
					ReflectionUtils.SetProperty(us, pi, "My Name");
			
			}
			
			*/
			//var fieldInfos = us.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
			//	foreach (var fieldInfo in fieldInfos)
			//	{
			//		Console.WriteLine( "fielInfoName :{0} ", fieldInfo.Name);
			//	}
			
					
			//Set one before use (i.e. in a static constructor).
			Config.DialectProvider = new FirebirdDialectProvider();
						
			Console.WriteLine(us.GetType().ToSelectStatement());
			
			Console.WriteLine(us.ToInsertRowStatement() );
			//Console.WriteLine(us.ToInsertSentence() );
			
			us.Name="some name";
			us.Password="jh";
			us.Col1="ll";
			us.Col2="xx";
			us.Col2="ys";
			Console.WriteLine(us.ToInsertRowStatement());
			Console.WriteLine(us.ToUpdateRowStatement());
			
			
			//using (FirebirdSql.Data.FirebirdClient.FbConnection db =
			//       new FirebirdSql.Data.FirebirdClient.FbConnection(
			//       "User=SYSDBA;Password=masterkey;Database=employee.fdb;DataSource=localhost;Dialect=3;charset=ISO8859_1;"))
			//{
			//	db.Open();
			//using (FirebirdSql.Data.FirebirdClient.FbCommand dbConn = db.CreateCommand())
			//{
			using (IDbConnection db =
			       "User=SYSDBA;Password=masterkey;Database=employee.fdb;DataSource=localhost;Dialect=3;charset=ISO8859_1;".OpenDbConnection())
			using ( IDbCommand dbConn = db.CreateCommand())
			{
				try{
					
					
    				dbConn.Insert(new User 
					{ 	
						Name= string.Format("Hello, World! {0}", DateTime.Now),
						Password="jkkoo",
						Col1="01",
						Col2="02",
						Col3="03"
							
					});
					
					User user = new User(){
						Name="New User ",
						Password= "kka",
						Col1="XX",
						Col2="YY",
						Col3="ZZ",
						Active=true
					};
					
					
					dbConn.Insert(user);
					
					Console.WriteLine("++++++++++Id for {0} {1}",user.Name,  user.Id);
						
					
    				var rows = dbConn.Select<User>();
					
					Console.WriteLine("++++++++++++++records in users {0}", rows.Count);
					foreach(User u in rows){
						Console.WriteLine("{0} -- {1} -- {2} -- {3} -{4} --{5} ", u.Id, u.Name, u.SomeStringProperty, u.SomeDateTimeProperty,
						                  (u.SomeInt32NullableProperty.HasValue)?u.SomeDateTimeNullableProperty.Value.ToString(): "",
						                  u.Active);
						Console.WriteLine(u.ToDeleteRowStatement());	
						dbConn.Delete(u);
					}
					
					rows = dbConn.Select<User>();
					
					Console.WriteLine("-------------records in users after delete {0}", rows.Count);
					
				}	
				
				catch(Exception e){
					Console.WriteLine(e);
				}

    //Assert.That(rows, Has.Count(1));
    //Assert.That(rows[0].Id, Is.EqualTo(1));
			}
			//}
		}
	}
}

