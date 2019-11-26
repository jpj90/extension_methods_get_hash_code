﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace ExtensionMethodsX
{
  public static class MyExtensions
  {

    //public static bool EqualsX(this object self, dynamic obj, List<PropertyInfo> excludeProperties)
    //{
    //  return self.GetHashCodeX(excludeProperties) == obj.GetHashCodeX(excludeProperties);
    //}

    public static int GetHashCode(this object self, List<PropertyInfo> excludeProperties)
    {
      List<PropertyInfo> props = new List<PropertyInfo>(self.GetType().GetProperties());

      if (excludeProperties != null && excludeProperties.Count > 0)
        excludeProperties.ForEach(prop => props.Remove(prop));

      var hashCode = 549824788;
      props.ForEach(prop => hashCode = hashCode * -1521134295 + prop.GetValue(self).GetHashCode());
      return hashCode > 0 ? hashCode : hashCode * -1;
    }
  }

}
