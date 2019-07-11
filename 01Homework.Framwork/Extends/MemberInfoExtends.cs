using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using _01Homework.Framwork.Attribute;

namespace _01Homework.Framwork.Extends
{
    public static class MemberInfoExtends
    {
        public static string GetName(this MemberInfo member)
        {
            if (member.IsDefined(typeof(NextLoadBaseAttribute), true))
            {
                var nextLoadAttributes = (NextLoadBaseAttribute)member.GetCustomAttribute(typeof(NextLoadBaseAttribute));
                return nextLoadAttributes.GetName();
            }
            else
            {
                return member.Name;
            }
        }

        public static void Valid<T>(this PropertyInfo[] properties, T t)
        {
            bool IsValid = true;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (PropertyInfo property in properties)
            {
                if (property.IsDefined(typeof(NextLoadRequiredAttribute), true))
                {
                    if (property.GetValue(t) == null)
                    {
                        IsValid = false;
                        dictionary.Add(property.Name, "Is Required");
                    }
                }

                if (property.IsDefined(typeof(NextLoadStringLengthAttribute), true))
                {
                    var nextLoadAttribute =
                        (NextLoadStringLengthAttribute)property.GetCustomAttribute(
                            typeof(NextLoadStringLengthAttribute));
                    object value = property.GetValue(t);
                    if (value == null || value.ToString().Length > nextLoadAttribute.MaxLength)
                    {
                        IsValid = false;
                        dictionary.Add(property.Name, "length must less than" + nextLoadAttribute.MaxLength);
                    }
                }

            }

            if (!IsValid)
            {
                StringBuilder sb = new StringBuilder();
                foreach (KeyValuePair<string, string> keyValuePair in dictionary)
                {
                    sb.Append("属性[").Append(keyValuePair.Key).Append("]").Append(keyValuePair.Value).Append("\t");
                }
                throw new Exception($"参数验证错误:{sb.ToString()}");
            }
        }


        //public static string GetName(this PropertyInfo property)
        //{
        //    if (property.IsDefined(typeof(NextLoadColumnAttribute), true))
        //    {
        //        var nextLoadAttributes = (NextLoadColumnAttribute)property.GetCustomAttribute(typeof(NextLoadColumnAttribute));
        //        return nextLoadAttributes.ColumnName;
        //    }
        //    else
        //    {
        //        return property.Name;
        //    }
        //}

        //public static string GetName(this Type type)
        //{
        //    if (type.IsDefined(typeof(NextLoadTableAttribute), true))
        //    {
        //        var nextLoadAttributes = (NextLoadTableAttribute)type.GetCustomAttribute(typeof(NextLoadTableAttribute));
        //        return nextLoadAttributes.TableName;
        //    }
        //    else
        //    {
        //        return type.Name;
        //    }
        //}
    }
}
