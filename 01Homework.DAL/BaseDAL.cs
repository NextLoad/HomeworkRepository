using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using _01Homework.Common._01HomeworkEnum;
using _01Homework.Factory;
using _01Homework.Framwork;
using _01Homework.Framwork.Extends;
using _01Homework.IDAL;
using _01Homework.Model;

namespace _01Homework.DAL
{
    public class BaseDAL : IBaseDAL
    {
        #region MyRegion
        //public  T Query(int id)
        //{
        //    T t = default(T);
        //    Type type = typeof(T);
        //    PropertyInfo[] properties = type.GetProperties();

        //    List<string> columnNames = new List<string>();
        //    foreach (PropertyInfo property in properties)
        //    {
        //        columnNames.Add("[" + property.GetName() + "]");
        //    }

        //    string columns = string.Join(",", columnNames.ToArray());

        //    string sqlTemplate = $"SELECT {columns} FROM [{type.GetName()}] WHERE ID=@Id";

        //    SqlParameter[] parameters = new[] { new SqlParameter("@Id", SqlDbType.Int) };
        //    parameters[0].Value = id;

        //    SqlDataReader sqlDataReader = SqlHelper.ExecuteQuery(sqlTemplate, parameters);
        //    if (sqlDataReader.Read())
        //    {
        //        t = Activator.CreateInstance<T>();
        //        foreach (PropertyInfo property in properties)
        //        {
        //            property.SetValue(t, sqlDataReader[property.GetName()] is DBNull ? null : sqlDataReader[property.GetName()]);
        //        }
        //    }

        //    return t;
        //}

        //public static IList<T> Query()
        //{
        //    IList<T> IList = new List<T>();
        //    Type type = typeof(T);
        //    PropertyInfo[] properties = type.GetProperties();

        //    List<string> columnNames = new List<string>();
        //    foreach (PropertyInfo property in properties)
        //    {
        //        columnNames.Add("[" + property.GetName() + "]");
        //    }

        //    string columns = string.Join(",", columnNames.ToArray());

        //    string sqlTemplate = $"SELECT {columns} FROM [{type.GetName()}]";

        //    SqlDataReader sqlDataReader = SqlHelper.ExecuteQuery(sqlTemplate);
        //    while (sqlDataReader.Read())
        //    {
        //        T t = Activator.CreateInstance<T>();
        //        foreach (PropertyInfo property in properties)
        //        {
        //            property.SetValue(t, sqlDataReader[property.GetName()] is DBNull ? null : sqlDataReader[property.GetName()]);
        //        }
        //        IList.Add(t);
        //    }

        //    return IList;
        //}

        //public static int Insert(T t)
        //{
        //    Type type = t.GetType();
        //    List<string> columnList = new List<string>();
        //    List<string> valueList = new List<string>();
        //    PropertyInfo[] properties = type.GetProperties();
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    foreach (var property in properties)
        //    {
        //        string propertyName = property.GetName();
        //        object propertyValue = property.GetValue(t);
        //        if (propertyName.ToLowerInvariant() == "id") continue;
        //        if (propertyValue == null) continue;
        //        columnList.Add("[" + propertyName + "]");
        //        valueList.Add("@" + propertyName);
        //        SqlParameter parameter = new SqlParameter("@" + propertyName, propertyValue);
        //        parameters.Add(parameter);
        //    }

        //    string columns = string.Join(",", columnList.ToArray());
        //    string values = string.Join(",", valueList.ToArray());


        //    string sqlTemplate = $"INSERT INTO [{type.GetName()}] ({columns}) VALUES({values})";
        //    return SqlHelper.ExecuteNonQuery(sqlTemplate, parameters.ToArray());

        //}

        //public static int Update(T t)
        //{
        //    if (t == null)
        //    {
        //        return 0;
        //    }

        //    T oldt = Query(t.Id);
        //    if (oldt == null)
        //    {
        //        return 0;
        //    }

        //    Type type = t.GetType();
        //    List<string> experssList = new List<string>();
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    foreach (PropertyInfo property in type.GetProperties())
        //    {
        //        string propertyName = property.GetName();
        //        if (propertyName.ToLowerInvariant() == "id") continue;
        //        object propertyValue = property.GetValue(t);
        //        if (propertyValue == null) continue;
        //        string expressStr = "[" + propertyName + "]" + " = @" + propertyName;
        //        experssList.Add(expressStr);
        //        parameters.Add(new SqlParameter("@" + propertyName, propertyValue));
        //    }
        //    string expressStrs = string.Join(",", experssList);
        //    string sqlTemplate = $"UPDATE {type.GetName()} SET {expressStrs} WHERE ID = @Id";
        //    parameters.Add(new SqlParameter("@Id", t.Id));
        //    return SqlHelper.ExecuteNonQuery(sqlTemplate, parameters.ToArray());
        //}

        //public static int Delete(int id)
        //{
        //    Type type = typeof(T);
        //    string sqlTemplate = $"DELETE FROM [{type.GetName()}] WHERE ID=@Id";
        //    SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Id", SqlDbType.Int) };
        //    parameters[0].Value = id;
        //    return SqlHelper.ExecuteNonQuery(sqlTemplate, parameters);
        //}

        //public static User Query2(int id)
        //{
        //    User user = null;
        //    string sql =
        //        "SELECT Id, Name, Account, Password, Email, Mobile, CompanyId, CompanyName, State, UserType, LastLoginTime, CreateTime, CreatorId, LastModifierId, LastModifyTime FROM [USER] WHERE ID=@Id";
        //    SqlParameter[] parameters = { new SqlParameter("@ID", SqlDbType.Int) };
        //    parameters[0].Value = id;

        //    SqlDataReader sqlDataReader = SqlHelper.ExecuteQuery(sql, parameters);
        //    if (sqlDataReader.Read())
        //    {
        //        user = new User();
        //        user.Id = Convert.ToInt32(sqlDataReader["Id"]);
        //        user.Name = sqlDataReader["Name"].ToString();
        //        user.Account = sqlDataReader["Account"].ToString();
        //        user.Password = sqlDataReader["Password"].ToString();
        //        user.Email = sqlDataReader["Email"].ToString();
        //        user.Mobile = sqlDataReader["Mobile"].ToString();
        //        user.CompanyId = Convert.ToInt32(sqlDataReader["CompanyId"]);
        //        user.CompanyName = sqlDataReader["CompanyName"].ToString();
        //        user.Status = Convert.ToInt32(sqlDataReader["State"]);
        //        user.UserType = Convert.ToInt32(sqlDataReader["UserType"]);
        //        user.LastLoginTime = Convert.ToDateTime(sqlDataReader["LastLoginTime"]);
        //        user.CreateTime = Convert.ToDateTime(sqlDataReader["CreateTime"]);
        //        user.CreatorId = Convert.ToInt32(sqlDataReader["CreatorId"]);
        //        user.LastModifierId = Convert.ToInt32(sqlDataReader["LastModifierId"]);
        //        user.LastModifyTime = Convert.ToDateTime(sqlDataReader["LastModifyTime"]);
        //    }

        //    return user;
        //}
        #endregion

        /// <summary>
        /// 根据主键Id查找
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Query<T>(int id) where T : BaseModel
        {
            T t = default(T);
            Type type = typeof(T);
            //获取类型中所有的属性
            PropertyInfo[] properties = type.GetProperties();

            List<string> columnNames = new List<string>();
            foreach (PropertyInfo property in properties)
            {
                columnNames.Add("[" + property.GetName() + "]");
            }

            string columns = string.Join(",", columnNames.ToArray());

            //拼装Sql语句
            string sqlTemplate = $"SELECT {columns} FROM [{type.GetName()}] WHERE ID=@Id";

            //参数化
            DbParameter[] parameters = new[] { DBFactory.GetDbParameter(StaticConstant.Dbtype) };
            parameters[0].ParameterName = "@Id";
            parameters[0].Value = id;

            using (DbDataReader DataReader = SqlHelper.ExecuteQuery(sqlTemplate, parameters))
            {
                //读取数据库
                if (DataReader.Read())
                {
                    t = Activator.CreateInstance<T>();
                    //给每个属性赋值
                    foreach (PropertyInfo property in properties)
                    {
                        property.SetValue(t, DataReader[property.GetName()] is DBNull ? null : DataReader[property.GetName()]);
                    }
                }
            }
            return t;
        }

        /// <summary>
        /// 查找单表所有记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IList<T> Query<T>() where T : BaseModel
        {
            IList<T> IList = new List<T>();
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();

            List<string> columnNames = new List<string>();
            foreach (PropertyInfo property in properties)
            {
                columnNames.Add("[" + property.GetName() + "]");
            }

            string columns = string.Join(",", columnNames.ToArray());

            string sqlTemplate = $"SELECT {columns} FROM [{type.GetName()}]";

            using (DbDataReader dataReader = SqlHelper.ExecuteQuery(sqlTemplate))
            {
                while (dataReader.Read())
                {
                    T t = Activator.CreateInstance<T>();
                    foreach (PropertyInfo property in properties)
                    {
                        property.SetValue(t, dataReader[property.GetName()] is DBNull ? null : dataReader[property.GetName()]);
                    }
                    IList.Add(t);
                }
            }

            return IList;
        }

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Insert<T>(T t) where T : BaseModel
        {
            Type type = t.GetType();
            List<string> columnList = new List<string>();
            List<string> valueList = new List<string>();
            PropertyInfo[] properties = type.GetProperties();
            //参数验证失败
            if (!t.Valid(out string errorMsg))
            {
                throw new Exception(errorMsg);
            }
            List<DbParameter> parameters = new List<DbParameter>();
            foreach (var property in properties)
            {
                string propertyName = property.GetName();
                object propertyValue = property.GetValue(t);
                if (propertyName.ToLowerInvariant() == "id") continue;
                if (propertyValue == null) continue;
                columnList.Add("[" + propertyName + "]");
                valueList.Add("@" + propertyName);
                DbParameter parameter = DBFactory.GetDbParameter(StaticConstant.Dbtype);
                parameter.ParameterName = "@" + propertyName;
                parameter.Value = propertyValue;
                parameters.Add(parameter);
            }

            string columns = string.Join(",", columnList.ToArray());
            string values = string.Join(",", valueList.ToArray());


            string sqlTemplate = $"INSERT INTO [{type.GetName()}] ({columns}) VALUES({values})";
            return SqlHelper.ExecuteNonQuery(sqlTemplate, parameters.ToArray());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update<T>(T t) where T : BaseModel
        {
            if (t == null)
            {
                return 0;
            }

            T oldt = Query<T>(t.Id);
            if (oldt == null)
            {
                return 0;
            }
            //参数验证失败
            if (!t.Valid(out string errorMsg))
            {
                throw new Exception(errorMsg);
            }
            Type type = t.GetType();
            List<string> experssList = new List<string>();
            List<DbParameter> parameters = new List<DbParameter>();
            foreach (PropertyInfo property in type.GetProperties())
            {
                string propertyName = property.GetName();
                if (propertyName.ToLowerInvariant() == "id") continue;
                object propertyValue = property.GetValue(t);
                if (propertyValue == null) continue;
                string expressStr = "[" + propertyName + "]" + " = @" + propertyName;
                experssList.Add(expressStr);


                DbParameter parameter = DBFactory.GetDbParameter(StaticConstant.Dbtype);
                parameter.ParameterName = "@" + propertyName;
                parameter.Value = propertyValue;
                parameters.Add(parameter);
            }
            string expressStrs = string.Join(",", experssList);
            string sqlTemplate = $"UPDATE {type.GetName()} SET {expressStrs} WHERE ID = @Id";
            DbParameter parameterId = DBFactory.GetDbParameter(StaticConstant.Dbtype);
            parameterId.ParameterName = "@Id";
            parameterId.Value = t.Id;
            parameters.Add(parameterId);

            return SqlHelper.ExecuteNonQuery(sqlTemplate, parameters.ToArray());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete<T>(int id) where T : BaseModel
        {
            Type type = typeof(T);
            string sqlTemplate = $"DELETE FROM [{type.GetName()}] WHERE ID=@Id";
            DbParameter parameterId = DBFactory.GetDbParameter(StaticConstant.Dbtype);
            parameterId.ParameterName = "@Id";
            parameterId.Value = id;
            DbParameter[] parameters = new DbParameter[] { parameterId };
            return SqlHelper.ExecuteNonQuery(sqlTemplate, parameters);
        }
    }
}
