using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01Homework.Factory;
using _01Homework.IDAL;
using _01Homework.Model;

namespace _01Homework.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IBaseDAL baseDal = DALFactory.CreateInstance();
                User user = baseDal.Query<User>(1);
                user.Name = "12123";
                user.Mobile = "233421121";
                baseDal.Insert(user);
                Console.WriteLine("ok");
                Console.Read();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
