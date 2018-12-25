using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ConsoleApplication1.Models;

namespace ConsoleApplication1.DataAccessLayer
{
    public class ClassContext: DbContext
    {
        public DbSet<Classandgrade> Classandgrade { get; set; }
        public DbSet<Student> Student { get; set; }
    }
}
