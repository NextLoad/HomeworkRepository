using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01Homework.Framwork.Attribute
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class NextLoadMobileAttribute : NextLoadAbstractValidAttribute
    {
        public override bool Valid(object value)
        {
            Regex regex = new Regex(@"^1([38][0-9]|4[579]|5[0-3,5-9]|6[6]|7[0135678]|9[89])\d{8}$");
            if (regex.IsMatch(value.ToString()))
            {
                return true;
            }

            return false;
        }
    }
}
