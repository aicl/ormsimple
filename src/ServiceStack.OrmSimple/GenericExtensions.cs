using System;
using System.Collections.Generic;
using System.Reflection;

using ServiceStack.Common.Utils;
using ServiceStack.OrmSimple;

namespace System.Collections.Generic
{
	public static class GenericExtensions
	{
		
		
		public static List<T>  Filter<T>(this List<T> records, 
		                                 string columnToFilter,
		                                 string valueToFilter,
		                                 CompareType compareType) where T: new() {
			
			if( string.IsNullOrEmpty(valueToFilter) ) return records;
			
			List<T> list= new List<T>();
			
			Type type = typeof(T);
			PropertyInfo pi= ReflectionUtils.GetPropertyInfo(type , columnToFilter );
			
			foreach(var r in records){
				object o= pi.GetValue(r, new object[]{} );
				
				string _value= (o != null)? o.ToString(): string.Empty;
				
				switch(compareType){
				case CompareType.Equal:
					if( object.Equals(_value, valueToFilter) ) list.Add(r);
					break;
				case CompareType.Contains:
					if( _value.ToUpper().Contains(valueToFilter.ToUpper()) ) list.Add(r);
					break;
				case CompareType.EndsWith:
					if( _value.ToUpper().EndsWith(valueToFilter.ToUpper()) ) list.Add(r);
					break;
				case CompareType.Greater:
					if( string.Compare(_value, valueToFilter) >0) list.Add(r);
					break;
				case CompareType.GreaterOrEqual:
					if( string.Compare(_value, valueToFilter) >=0) list.Add(r);
					break;
				case CompareType.Less:
					if( string.Compare(_value, valueToFilter) < 0) list.Add(r);
					break;
				case CompareType.LessOrEqual:
					if( string.Compare(_value, valueToFilter) <= 0) list.Add(r);
					break;
				case CompareType.StarsWith:	
					if( _value.ToUpper().EndsWith(valueToFilter.ToUpper()) ) list.Add(r);
					break;
				}
					
			}
			
			return list; 
		}
		
		
		
	}
}

/*
				if(pi.PropertyType==typeof(string)){
					string s = (string)o;
					if(s.Contains(valueToFilter)) list.Add(r);
				}
				else{
					if( object.Equals(o.ToString(), valueToFilter) ) list.Add(r);
				}
				//if(pi.PropertyType==typeof(Int64)){	
				//	if( Convert.ToInt64(o)== Int64.Parse(valueToFilter) ) 	list.Add(r);
				//}
				*/
				