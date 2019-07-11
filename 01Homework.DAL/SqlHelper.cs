using _01Homework.Factory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01Homework.Common._01HomeworkEnum;
using _01Homework.Framwork;

namespace _01Homework.DAL
{
    public class SqlHelper
    {
        public static int ExecuteNonQuery(string sql, params DbParameter[] parameters)
        {
            using (DbConnection conn = DBFactory.GetDbConnection(StaticConstant.Dbtype))
            {
                using (DbCommand cmd = conn.CreateCommand())
                {
                    conn.ConnectionString = StaticConstant.sqlConnstr;
                    conn.Open();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static DbDataReader ExecuteQuery(string sql, params DbParameter[] parameters)
        {
            DbConnection conn = DBFactory.GetDbConnection(StaticConstant.Dbtype);
            conn.ConnectionString = StaticConstant.sqlConnstr;
            DbCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteReader();
        }
    }
}
