﻿using System;
using System.Linq;

namespace TradeWithNarnia.Helper
{
  public static class EnumHelper
  {
    /// <summary>
    /// Gets an attribute on an enum field value
    /// </summary>
    /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
    /// <param name="enumVal">The enum value</param>
    /// <returns>The attribute of type T that exists on the enum value</returns>
    public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
    {
      var type = enumVal.GetType();
      var memInfo = type.GetMember(enumVal.ToString());
      var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
      if (attributes.Any())
      {
        return (T) attributes[0];
      }
      return null;
    }
  }
}
