using System;
namespace ServiceStack.OrmSimple.DbSchema
{
	public interface IProcedure
	{
		
		string  Name { get; set; }
		
		
    	string Owner { get; set; }
		
		
		Int16 Inputs{ get ; set;}
		
		
		Int16 Outputs{ get ; set;}
		
		
		ProcedureType Type{ get; } 
		
	}
}

