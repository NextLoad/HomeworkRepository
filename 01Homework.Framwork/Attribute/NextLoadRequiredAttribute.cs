using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Homework.Framwork.Attribute
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class NextLoadRequiredAttribute : NextLoadAbstractValidAttribute
    {
        public override string ErrorMsg { get; set; } = "must required!";
        public NextLoadRequiredAttribute() { }
        public override bool Valid(object value)
        {
            if (value == null)
            {
                return false;
            }

            return true;
        }
    }
}
