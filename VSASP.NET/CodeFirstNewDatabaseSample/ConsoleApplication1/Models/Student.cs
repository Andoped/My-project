using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Models
{
    public class Student
    {
        //学生ID
        public int Studentid { get; set; }
        //学生的姓名
        public string name { get; set; }
        //学生的成绩
        public int score { get; set; }


        public int Classandgradeid { get; set; }
        public virtual Classandgrade Classandgrade { get; set; }
    }
}
