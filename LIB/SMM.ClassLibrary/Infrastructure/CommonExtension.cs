using SMM.ClassLibrary.Infrastructure.Attributes;
using SMM.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SMM.ClassLibrary.Infrastructure
{
    public static class CommonExtension
    {
            public static string JsonValue(this ListOrderBy value)
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());

            JsonValueAttribute attribute = fi.GetCustomAttributes(typeof(JsonValueAttribute), false).First() as JsonValueAttribute;

                if (attribute != null)
                {
                    return attribute.ValueName;
                }
            return string.Empty;
            }
    }
}
