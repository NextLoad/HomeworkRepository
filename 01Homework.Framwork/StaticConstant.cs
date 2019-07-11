using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01Homework.Common._01HomeworkEnum;

namespace _01Homework.Framwork
{
    public class StaticConstant
    {
        //数据库连接字符串
        public static string sqlConnstr = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;

        public static DBType Dbtype =
            (DBType)Enum.Parse(typeof(DBType), ConfigurationManager.AppSettings["DbType"]);


        public static string BaseDalAssemblyName = ConfigurationManager.AppSettings["BaseDALAssembly"].Split(',')[1];
        public static string BaseDalClassName = ConfigurationManager.AppSettings["BaseDALAssembly"].Split(',')[0];



    }
}
