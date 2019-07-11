using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01Homework.Framwork.Attribute
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class NextLoadEmailAttribute : NextLoadAbstractValidAttribute
    {
        public override bool Valid(object value)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$");
            if (regex.IsMatch(value.ToString()))
            {
                return true;
            }

            return false;
        }
    }
}
