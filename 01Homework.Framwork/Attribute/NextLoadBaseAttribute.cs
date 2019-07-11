using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Homework.Framwork.Attribute
{
    public abstract class NextLoadBaseAttribute : System.Attribute
    {
        public abstract string GetName();
    }
}
