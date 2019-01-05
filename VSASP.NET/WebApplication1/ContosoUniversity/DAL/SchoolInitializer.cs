using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.DAL
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<Student>
            {
                new Student {Name="卡拉夫",EnrollmentDate=DateTime.Parse("2019-1-3") },
                new Student {Name="卡罗拉",EnrollmentDate=DateTime.Parse("2019-2-3") },
                new Student {Name="叶卡捷琳堡",EnrollmentDate=DateTime.Parse("2018-5-3") },
                new Student {Name="卡尔",EnrollmentDate=DateTime.Parse("2019-1-3") },
                new Student {Name="卡雷拉",EnrollmentDate=DateTime.Parse("2019-1-3") },
                new Student {Name="001",EnrollmentDate=DateTime.Parse("2018-9-3") },
                new Student {Name="002",EnrollmentDate=DateTime.Parse("2018-10-3") },
                new Student {Name="003",EnrollmentDate=DateTime.Parse("2018-11-3") },
                new Student {Name="004",EnrollmentDate=DateTime.Parse("2018-12-3") }
            };
            //将课程数据加入实体集
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
            new Course{CourseID=1050,Title="Chemistry",Credits=3,},
            new Course{CourseID=4022,Title="Microeconomics",Credits=3,},
            new Course{CourseID=4041,Title="Macroeconomics",Credits=3,},
            new Course{CourseID=1045,Title="Calculus",Credits=4,},
            new Course{CourseID=3141,Title="Trigonometry",Credits=4,},
            new Course{CourseID=2021,Title="Composition",Credits=3,},
            new Course{CourseID=2042,Title="Literature",Credits=4,}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();
            var enrollments = new List<Enrollment>
            {
            new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A}
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();

        }


    }
}