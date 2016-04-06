using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace Nancy.ViewEngines.Razor.Html
{
    public static class PropertyInfoExtensions
    {
        public static string GetPresentationName(this PropertyInfo property)
        {
            var displayAttr = property.GetCustomAttribute<DisplayNameAttribute>();
            return displayAttr != null ? displayAttr.DisplayName : property.Name;
        }

        public static string GetValueAsString(this PropertyInfo property, object thisObject)
        {
            var valueString = string.Empty;
            if (!property.CanRead)
            {
                return valueString;
            }
            var valueObject = property.GetValue(thisObject);
            valueString = valueObject != null ? Convert.ToString(valueObject) : string.Empty;
            return valueString;
        }

        public static PropertyInfo AsPropertyInfo<T, TR>(this Expression<Func<T, TR>> expr)
        {
            var memExpr = expr.Body as MemberExpression;
            return memExpr != null ? memExpr.Member as PropertyInfo : null;
        }
    }
}