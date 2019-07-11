using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using _01Homework.Framwork;
using _01Homework.Framwork.Attribute;

namespace _01Homework.Model
{
    public class Company : BaseModel
    {
        [NextLoadDisplayName("名称")]
        public string Name { get; set; }
    }
}
