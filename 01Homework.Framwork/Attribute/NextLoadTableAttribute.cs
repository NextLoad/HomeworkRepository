using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Homework.Framwork.Attribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class NextLoadTableAttribute : NextLoadBaseAttribute
    {
        private string tableName;
        public string TableName
        {
            get { return tableName; }
        }
        public NextLoadTableAttribute(string tableName)
        {
            this.tableName = tableName;
        }

        public override string GetName()
        {
            return TableName;
        }
    }
}
