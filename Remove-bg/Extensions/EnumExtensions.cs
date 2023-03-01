using System;
using System.ComponentModel;
using System.Reflection;

namespace Removebg.Extensions
{
  internal static class EnumExtensions
  {
    /// <summary>
    /// Gets the description attribute from enumeration.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    public static string GetDescription(this Enum value)
    {
      FieldInfo field = value.GetType().GetField(value.ToString());
      return !(Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute) ? string.Empty : attribute.Description;
    }
  }
}
