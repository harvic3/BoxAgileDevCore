namespace BoxAgileDevCore.Application.Mapping
{
  public static class ReflectionUtil
  {
    public static bool HasProperty( this object obj, string propertyName )
    {
      return obj.GetType().GetProperty( propertyName ) != null;
    }

    public static T GetPropertyValue<T>( this object obj, string propertyName )
    {
      if ( obj.HasProperty( propertyName ) )
      {
        return (T)obj.GetType().GetProperty( propertyName ).GetValue( obj, null );
      }

      return default;
    }
  }
}
