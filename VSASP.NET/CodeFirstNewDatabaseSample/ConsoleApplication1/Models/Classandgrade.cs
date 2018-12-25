using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Models
{
    public class Classandgrade
    {
        //班级ID
        public int Classandgradeid { get; set; }
        //课程
        public string Curriculum { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
