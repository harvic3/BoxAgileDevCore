using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace BoxAgileDevCore.Application.Mapping
{
  /// <summary>
  /// Class for mapping objects.
  /// </summary>
  public class SimpleMapper
  {
    /// <summary>
    /// Method to map a dto object to domain object or viceversa.
    /// </summary>
    /// <typeparam name="T">Object type</typeparam>
    /// <param name="origin">Object of origin data.</param>
    /// <param name="destination">Object to destination data.</param>
    /// <returns></returns>
    private static T Map<T>( object origin, T destination )
    {
      if ( origin == null )
      {
        return default( T );
      }

      PropertyInfo[] destProperties = destination.GetType().GetProperties();

      Type originProperties = origin.GetType();

      foreach ( PropertyInfo prop in destProperties )
      {
        PropertyInfo value = originProperties.GetProperty( prop.Name );

        if ( value != null )
        {
          if ( prop.PropertyType.IsPrimitive ||
              prop.PropertyType.Name == "Decimal" ||
              prop.PropertyType.Name == "String" ||
              prop.PropertyType.Name == "DateTime" ||
              prop.PropertyType.IsValueType )
          {
            prop.SetValue( destination, value.GetValue( origin, null ), null );
          }
          else if ( prop.GetType().IsSubclassOf( typeof( IEnumerable ) ) )
          {
            // TODO: Map object collection

          }
          else
          {
            var originInt = value.GetValue( origin, null );
            prop.SetValue( destination, Map( originInt, Activator.CreateInstance( prop.PropertyType ) ) );
          }
        }
      }

      return destination;
    }

    /// <summary>
    /// FUnction to map the properties a type object to other similar dto/domain object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="origin"></param>
    /// <returns></returns>
    public static T MapObject<T>( object origin )
    {
      T dest = Activator.CreateInstance<T>();

      return Map<T>( origin, dest );
    }

    /// <summary>
    /// Function for map a object collection.
    /// </summary>
    /// <typeparam name="T">The type of object to be converted.</typeparam>
    /// <param name="data">List of object to map.</param>
    /// <returns></returns>
    public static List<Tout> MapCollection<Tin, Tout>( IEnumerable<Tin> data )
    {
      List<Tout> results = new List<Tout>();
      foreach ( var item in data )
      {
        results.Add( MapObject<Tout>( item ) );
      }

      return results;
    }

  }

}
