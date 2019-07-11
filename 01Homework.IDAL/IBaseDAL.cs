using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01Homework.Framwork;
using _01Homework.Model;

namespace _01Homework.IDAL
{
    public interface IBaseDAL
    {
        T Query<T>(int id) where T : BaseModel;
        IList<T> Query<T>() where T : BaseModel;
        int Insert<T>(T t) where T : BaseModel;
        int Update<T>(T t) where T : BaseModel;
        int Delete<T>(int id) where T : BaseModel;
    }
}
