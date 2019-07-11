using _01Homework.Framwork;
using _01Homework.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _01Homework.Factory
{
    public class DALFactory
    {
       
        public static IBaseDAL CreateInstance()
        {
            Assembly assembly = Assembly.Load(StaticConstant.BaseDalAssemblyName);
            Type type = assembly.GetType(StaticConstant.BaseDalClassName);
            return (IBaseDAL)Activator.CreateInstance(type);
        }
    }
}
