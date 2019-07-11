using _01Homework.Common._01HomeworkEnum;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Homework.Factory
{
    public class DBFactory
    {
        public static DbConnection GetDbConnection(DBType dbType)
        {
            switch (dbType)
            {
                case DBType.MySql:
                    return new MySqlConnection();
                case DBType.SQLServer:
                    return new SqlConnection();
                default: return new SqlConnection();
            }
        }

        public static DbParameter GetDbParameter(DBType dbType)
        {
            switch (dbType)
            {
                case DBType.MySql:
                    return new MySqlParameter();
                case DBType.SQLServer:
                    return new SqlParameter();
                default: return new SqlParameter();
            }
        }
    }
}
