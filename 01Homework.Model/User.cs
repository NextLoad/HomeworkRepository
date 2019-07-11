using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01Homework.Framwork;
using _01Homework.Framwork.Attribute;
using _01Homework.Model;

namespace _01Homework.Model
{
    [NextLoadTable("User")]
    public class User : BaseModel
    {
        [NextLoadDisplayName("姓名")]        
        [NextLoadStringLength(8,ErrorMsg = "最大长度为8")]
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        [NextLoadEmail]
        public string Email { get; set; }
        [NextLoadRequired]
        [NextLoadMobile]
        public string Mobile { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        [NextLoadColumn("State")]
        public int Status { get; set; }
        public int UserType { get; set; }
        [Required]
        public DateTime LastLoginTime { get; set; }
    }
}
