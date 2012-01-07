using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Data;

using ServiceStack.DataAnnotations;
using System.Reflection;

using ServiceStack.OrmSimple;
using ServiceStack.OrmSimple.DbSchema;
using ServiceStack.OrmSimple.Firebird;

using System.Linq;

using Database.Records;

namespace Maquinaria
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			
			Config.DialectProvider = new FirebirdDialectProvider(); 
			using (IDbConnection db =
			       //"User=SYSDBA;Password=masterkey;Database=MAQUINARIA.FDB;DataSource=172.16.7.40;Dialect=3;charset=ISO8859_1;".OpenDbConnection())
			       ("User=SYSDBA;Password=masterkey;Database=employee.fdb;" +
			       	"DataSource=localhost;Dialect=3;charset=ISO8859_1;").OpenDbConnection())
			       
			       //("User=SYSDBA;Password=masterkey;Database=/home/angel/bd/INTER2011/INTERNACIONAL2011.FDB;" +
			       //	"DataSource=localhost;Dialect=3;charset=ISO8859_1;").OpenDbConnection())
			using ( IDbCommand dbConn = db.CreateCommand())
			{
				
				Schema fbd= new Schema(){
					Connection = db
				};
				
				ClassWriter cw = new ClassWriter(){
					Schema=fbd,
				};
				
				foreach(var t in fbd.Tables){
					cw.WriteClass( t);	
				}
				
				/*Table t = new Table(){Name=	"CONCEPTO"};
				cw.WriteClass(t);
				*/
				
				//var materiales = dbConn.Select<Materialsuc>(" MATID='{0}' AND SUCID='{1}'", 9136,30) ;
				/*
				var kardex = dbConn.Select<Kardex>(" NUMERO LIKE 'RMDT%' ORDER BY  NUMERO DESC ROWS 1 ") ;
				var r = kardex.FirstOrDefault();
				if( r != default(Kardex) )
				   Console.WriteLine( r.Numero);
				*/
				
				//var concepto = dbConn.Select<Concepto>(" CODIGO = '{0}' ROWS 1 ", "000292") ; //does not work !!!
				/*var concepto = dbConn.Select<Concepto>( string.Format(" CODIGO = '{0}' ROWS 1 ", "000292") );
				var c = concepto.FirstOrDefault();
				if( c != default(Concepto) )
				   Console.WriteLine( c.Descrip );
				*/
				
				//Console.WriteLine(materiales.Count);
				//Console.WriteLine("there is company with id:'{0}' ? {1}",
				//                  5,
				//                  dbConn.Exists<Company>( "Id='{0}'",5 ) );
				
				//Console.WriteLine("there is company with id:'{0}' ? {1}",
				//                  100,
				//                  dbConn.Exists<Company>( "Id='{0}'",100 )) ;
				
				
				
				Company cp = new Company{Id=5};
					
			
				Console.WriteLine("there is company with id:'{0}' ? {1}",
				                  cp.Id,
				                  dbConn.Exists<Company>( cp ) );
				
				cp.Id=100;
				Console.WriteLine("there is company with id:'{0}' ? {1}",
				                  cp.Id,
				                  dbConn.Exists<Company>( cp )) ;
				
				Console.WriteLine(dbConn.HasChildren<Customer>(new Customer(){Id=20}) );
				Console.WriteLine(dbConn.HasChildren<Customer>(new Customer(){Id=1001}) );
				
				Customer cust =new Customer(){ Id=20};
				
				Console.WriteLine("Has customer with Id:'{0}' Children in Sales ? {1}",
				                  cust.Id,
				                  dbConn.HasChildren<Sales>(cust) );
				cust.Id=1001;
				
				Console.WriteLine("Has customer with Id:'{0}' Children in Sales ? {1}",
				                  cust.Id,
				                  dbConn.HasChildren<Sales>(cust) );
				
				
				
			}
			
			
			Console.WriteLine ("This is The End my friend!");
		}
		
	}
}



