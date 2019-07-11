using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using _01Homework.Framwork.Attribute;


namespace _01Homework.Framwork.Extends
{
    public static class BaseModelExtends
    {
        public static string DisplayName(this BaseModel baseModel, string propertyName)
        {
            string displayName = string.Empty;
            Type type = baseModel.GetType();
            var properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (propertyName == property.Name)
                {
                    if (property.IsDefined(typeof(NextLoadDisplayNameAttribute), true))
                    {
                        var attribute = (NextLoadDisplayNameAttribute)property.GetCustomAttribute(typeof(NextLoadDisplayNameAttribute));
                        displayName = attribute.DisplayName;
                    }
                    break;
                }
            }

            return displayName;
        }

        public static bool Valid(this BaseModel baseModel, out string errorMsg)
        {
            errorMsg = string.Empty;
            Type type = baseModel.GetType();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                //找出标记了验证相关的特性
                if (property.IsDefined(typeof(NextLoadAbstractValidAttribute), true))
                {
                    var attributes = (NextLoadAbstractValidAttribute[])property.GetCustomAttributes(typeof(NextLoadAbstractValidAttribute), true);
                    foreach (var attribute in attributes)
                    {
                        object value = property.GetValue(baseModel);
                        //验证失败
                        if (!attribute.Valid(value))
                        {
                            errorMsg = $"属性[{property.Name}]:{value},错误:{attribute.ErrorMsg}";
                            return false;
                        }
                    }
                }
            }

            return true;
        }

    }
}
