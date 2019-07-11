using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Homework.Framwork.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NextLoadDisplayNameAttribute : System.Attribute
    {
        private string displayName;
        public string DisplayName
        {
            get
            {
                return displayName;
            }
        }

        public NextLoadDisplayNameAttribute(string displayName)
        {
            this.displayName = displayName;
        }
    }
}
