using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Homework.Framwork.Attribute
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class NextLoadStringLengthAttribute : NextLoadAbstractValidAttribute
    {
        public override string ErrorMsg { get; set; } = "值的长度不正确";
        public int MinLength { get; set; }
        public int MaxLength { get; private set; }
        public NextLoadStringLengthAttribute(int MaxLength)
        {
            this.MaxLength = MaxLength;
        }

        public override bool Valid(object value)
        {
            if (value == null)
            {
                return false;
            }

            if (value.ToString().Length > MinLength && value.ToString().Length <= MaxLength)
            {
                return true;
            }

            return false;
        }
    }
}
