using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.Models;
using CodeFirstNewDatabaseSample.BussinessLayert;
using CodeFirstNewDatabaseSample.DataAccessLayer;

namespace CodeFirstNewDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddPost();
            //Deletes();
            //Updates();
            //crateBlog();
            //QueryBlog();
            //Delete();
            ////Update();
            //QueryBlog();
            //blogger();
            Method();


        }
        static void Method()
        {
            Console.WriteLine("\n请选择您要的操作:  1-博客操作   2-帖子操作   3-退出");
            int number = int.Parse(Console.ReadLine());
            if (number == 1)
            {
                blogger();
            }
            else if (number == 2)
            {
                QueryBlog();
                Postoperation();
            }else if (number == 3)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("对不起,您输入了无效的操作!");
                Method();
            }
            Console.WriteLine("点任意件,退出!");
            Console.Read();
        }
        /// <summary>
        /// ____________博客操作_____________
        /// </summary>
        static void blogger()
        {
            QueryBlog();
            Console.WriteLine("\n请选择您要的操作: 1-新增博客   2-修改博客   3-删除博客   4-帖子列表  5-返回");
            int number = int.Parse(Console.ReadLine());
            if (number == 1)
            {
                crateBlog();
                QueryBlog();
                Method();
            }
            else if (number == 2)
            {
                Update();
                QueryBlog();
                Method();
            }
            else if (number == 3)
            {
                Console.WriteLine("\n您是否要删除博客  1-是   2-我在想想");
                int num = int.Parse(Console.ReadLine());
                if (num==1)
                {
                    Delete();
                    QueryBlog();
                    Method();
                }
                else if (num==2)
                {
                    Method();
                }
                
            }
            else if (number == 4)
            {
                Postoperation();
            }else if (number == 5)
            {
                Method();
            }
            else
            {
                Console.WriteLine("对不起,您输入了无效的操作!");
            }
        }
        /// <summary>
        /// ____________帖子操作_____________
        /// </summary>
        static void Postoperation()
        {
            QueryBlogs();
            Console.WriteLine("\n请选择您要的操作: 1-新增帖子   2-修改帖子   3-删除帖子   4-返回");
            int number = int.Parse(Console.ReadLine());
            if (number==1)
            {
                Createnewposts();
                QueryBlogs();
                Method();
            }
            else if (number == 2)
            {
                Updates();
                QueryBlogs();
                Method();
            }
            else if (number == 3)
            {
                Deletes();
                QueryBlogs();
                Method();
            }
            else if (number == 4)
            {
                Method();
            }
        }
        static void AddPost()
        {
            //显示博客列表
            QueryBlog();
            //用户选择某个博客（id）
            int shu = GetBlogId();
            //显示指定博客的帖子列表
            DisplayPsts(shu);
            //根据指定到博客信息创建新帖子  
            //Createnewposts();
            //显示指定博客的帖子列表
            DisplayPsts(shu);
        }
        /// <summary>
        /// -----这里是全部帖子的列表--------
        /// </summary>
        ///这里是增加帖子的方法
        static void Createnewposts()
        {
            Post post = new Post();
            Console.Write("请用户输入ID");
            post.BlogId = int.Parse(Console.ReadLine());
            Console.Write("请用户输入标题");
            post.Title = Console.ReadLine();
            Console.Write("请用户输入内容");
            post.Content = Console.ReadLine();
            PostBusinessLayert pbl = new PostBusinessLayert();
            pbl.Add(post);
            DisplayPsts(post.BlogId);
        }
        /// 这里是根据博客的ID显示帖子标题
        /// <param name="shu"></param>
        static void DisplayPsts(int shu)
        {
            //根据博客ID获取博客
            //BlogBusinessLayert bbl = new BlogBusinessLayert();
            //if (shu!=0)
            //{
            //    Blog bl = bbl.Query(shu);
            //    //Console.WriteLine(bl.Name);
            //}
            //在这放变量是为了不被销毁
            List<Post> list = null;
            //在Using内｛｝定义的用完就会销毁
            using (var db=new BloggingContext())//数据库的上下文
            {
                Blog blog = db.Blogs.Find(shu);//通过ID查找
                //根据博客导航属性,获取所有该博客的帖子
                list = blog.Posts;//把取得的值给list
            }
            //遍历所有帖子,显示帖子标题
            foreach (var item in list)
            {
                Console.WriteLine("[{0}]博客的消息:{1}",item.Blog.BlogId,item.Title);
            } 
        }
        /// 这里是获取博客的ID方法
        static int GetBlogId()
        {
            Console.Write("请输入博客的ID来查询帖子");
            int str = int.Parse(Console.ReadLine());
            return str;
        }
        /// 这里是删除帖子的方法
        static void Deletes()
        {
            Console.Write("请您输入要删除帖子的ID");
            int str = int.Parse(Console.ReadLine());
            PostBusinessLayert bpl = new PostBusinessLayert();
            List<Post> list = null;
            //在Using内｛｝定义的用完就会销毁
            using (var db = new BloggingContext())//数据库的上下文
            {
                Blog blog = db.Blogs.Find(str);//通过ID查找
                //根据博客导航属性,获取所有该博客的帖子
                list = blog.Posts;//把取得的值给list
            }
            for (int i = 0; i < list.Count; i++)
            { 
                bpl.Delete(list[i]);
            }
            DisplayPsts(str);

        }
        /// 这里是修改帖子的方法
        static void Updates()
        {
            QueryBlogs();
            Console.Write("请输入您要修改的，帖子的ID：");
            int str=int.Parse(Console.ReadLine());
            PostBusinessLayert bpl = new PostBusinessLayert();
            Post post = bpl.Query(str);
            Console.Write("请输入您要修改的标题:");
            string src = Console.ReadLine();
            post.Title = src;
            Console.Write("请输入您要修改的内容:");
            string sq = Console.ReadLine();
            post.Content = sq;
            bpl.Update(post);
            QueryBlogs();
        }
        /// 这里是显示全部的帖子内容的方法
        static void QueryBlogs()
        {
            PostBusinessLayert bpl = new PostBusinessLayert();
            var posts = bpl.Query();
            foreach (var item in posts)
            {
                Console.WriteLine("帖子ID:[{0}]  标题:{1}  内容:{2}",item.PostId, item.Title, item.Content);
            }
        }



        /// <summary>
        /// -------这里是全部博客的列表--------
        /// </summary>
        static void crateBlog()
        {
            Console.WriteLine("请输入一条消息!");
            string name = Console.ReadLine();
            Blog blog = new Blog();
            blog.Name = name;
            BlogBusinessLayert bll = new BlogBusinessLayert();
            bll.Add(blog);
        }
        static void QueryBlog()
        {
            BlogBusinessLayert bbl = new BlogBusinessLayert();
            var blogs = bbl.Query();
            foreach (var item in blogs)
            {
                Console.WriteLine("ID:{0}   消息:{1}",item.BlogId,item.Name);
            }
        }
        static void Update()
        {
            Console.Write("请输入要修改的ID:");
            int id=int.Parse(Console.ReadLine());
            BlogBusinessLayert bbl = new BlogBusinessLayert();
            Blog blog = bbl.Query(id);
            Console.Write("请输入要修改的消息:");
            string name = Console.ReadLine();
            blog.Name = name;
            bbl.Update(blog);
        }
        static void Delete()
        {
            Console.Write("请输入ID:");
            int id = int.Parse(Console.ReadLine());
            BlogBusinessLayert bbl = new BlogBusinessLayert();
            Blog blog = bbl.Query(id) ;
            bbl.Delete(blog);
            Console.WriteLine("删除完成!");
        }

    }
}
