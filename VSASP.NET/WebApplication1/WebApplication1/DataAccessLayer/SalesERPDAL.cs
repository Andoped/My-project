namespace WebApplication1.DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using WebApplication1.Models;
    //数据库的上下文SalesERPDAL    连接数据库DbContext
    public class SalesERPDAL : DbContext
    {
        //数控的表名Employees
        public virtual DbSet<Employee> Employees { get; set; }
    }


}