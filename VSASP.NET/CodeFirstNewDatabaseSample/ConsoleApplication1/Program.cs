using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Models;
using ConsoleApplication1.BussinessLayert;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryClass();
            QueryBlog();
            Update();
            QueryBlog();  
            Delete();
            QueryBlog();
            Console.WriteLine("点任意件,退出!");
            Console.Read();
        }

        static void QueryClass()
        {
            Console.WriteLine("请输入一个课程:");
            string b = Console.ReadLine();
            Classandgrade cla = new Classandgrade();
            cla.Curriculum = b;
            BlogBusinessLayert bbl = new BlogBusinessLayert();
            bbl.Add(cla);
                
        }
        static void QueryBlog()
        {
            BlogBusinessLayert bbl = new BlogBusinessLayert();
            var blogs = bbl.Query();
            foreach (var item in blogs)
            {
                Console.WriteLine("ID:{0}   消息:{1}", item.Classandgradeid, item.Curriculum);
            }
        }
        static void Update()
        {
            Console.Write("请输入要修改的ID:");
            int id = int.Parse(Console.ReadLine());
            BlogBusinessLayert bbl = new BlogBusinessLayert();
            Classandgrade cla = bbl.Query(id);
            Console.Write("请输入要修改的消息:");
            string name = Console.ReadLine();
            cla.Curriculum = name;
            bbl.Update(cla);
        }
        static void Delete()
        {
            Console.Write("请输入ID:");
            int id = int.Parse(Console.ReadLine());
            BlogBusinessLayert bbl = new BlogBusinessLayert();
            Classandgrade cla = bbl.Query(id);
            bbl.Delete(cla);
        }
       
    }
}
