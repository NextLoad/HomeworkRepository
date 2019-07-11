using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Homework.Framwork.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NextLoadColumnAttribute : NextLoadBaseAttribute
    {
        private string columnName;
        public override string Name
        {
            get { return columnName; }
        }
        public NextLoadColumnAttribute(string columnName)
        {
            this.columnName = columnName;
        }

    }
}
