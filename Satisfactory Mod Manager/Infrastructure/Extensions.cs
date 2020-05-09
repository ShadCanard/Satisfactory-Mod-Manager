using Satisfactory_Mod_Manager.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Satisfactory_Mod_Manager.Infrastructure
{
    public static class Extensions
    {
        /// <summary>
        /// Returns File Path from a type.
        /// </summary>
        /// <param name="type">Type to search</param>
        /// <returns></returns>
        public static string GetFilePath(this Type type)
        {
            FilePathAttribute attribute = type.GetCustomAttributes(typeof(FilePathAttribute), false).FirstOrDefault() as FilePathAttribute;

            if (attribute != null)
            {
                return attribute.Path;
            }
            return string.Empty;
        }

        public static string Description(this object value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

        public static IEnumerable<T> FindVisualChildren<T>(this DependencyObject depObj) where T : DependencyObject
        {
            if(depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if(child !=null && child is T)
                    {
                        yield return (T)child;
                    }
                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

    }
}
