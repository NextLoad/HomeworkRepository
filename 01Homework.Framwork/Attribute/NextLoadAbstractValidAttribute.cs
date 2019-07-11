using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Homework.Framwork.Attribute
{
    public abstract class NextLoadAbstractValidAttribute : System.Attribute
    {
        public virtual String ErrorMsg { get; set; }
        public abstract bool Valid(object value);
    }
}
