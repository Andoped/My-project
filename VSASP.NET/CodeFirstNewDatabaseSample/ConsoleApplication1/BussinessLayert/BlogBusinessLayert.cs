using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Models;
using ConsoleApplication1.DataAccessLayer;
using System.Data.Entity;

namespace ConsoleApplication1.BussinessLayert
{
    public class BlogBusinessLayert
    {
        public void Add(Classandgrade classandgrade)
        {
            using (var db = new ClassContext())
            {
                db.Classandgrade.Add(classandgrade);
                db.SaveChanges();
            }

        }
        public List<Classandgrade> Query()
        {
            using (var db=new ClassContext())
            {
                return db.Classandgrade.ToList();
            }
        }
        public Classandgrade Query(int id)
        {
            using (var db=new ClassContext())
            {
                return db.Classandgrade.Find(id);
            }
        }
        public void Update(Classandgrade classandgrade)
        {
            using (var db=new ClassContext())
            {
                db.Entry(classandgrade).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(Classandgrade classandgrade)
        {
            using (var db=new ClassContext())
            {
                db.Entry(classandgrade).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }



    }
}
