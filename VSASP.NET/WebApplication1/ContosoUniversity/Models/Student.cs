using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }
        //名字
        public string Name { get; set; }
        //时间
        public DateTime EnrollmentDate { get; set; }
        //头像地址
        [Display(Name="头像")]
        public string Image { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}