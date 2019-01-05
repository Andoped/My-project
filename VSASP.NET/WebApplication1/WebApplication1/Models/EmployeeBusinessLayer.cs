using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DataAccessLayer;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployeeList()
        {
            using (SalesERPDAL dal = new SalesERPDAL())
            {
              
                var list = dal.Employees.ToList();
                return list;
            }   
        }
        public void Add(Employee emp)
        {
            using (SalesERPDAL dal=new SalesERPDAL())
            {
                dal.Employees.Add(emp);
                dal.SaveChanges();
            }
        }
        public Employee Query(int id)
        {
            using (SalesERPDAL dal = new SalesERPDAL())
            {

                return dal.Employees.Find(id);  
            }
        }
        public IEnumerable<Employee> Querys(string searchString)
        {
            using (SalesERPDAL dal=new SalesERPDAL())
            {
                return dal.Employees.Where(e=> e.Name.Contains(searchString)).ToList();
            }
        }


        public void Delete(int id)
        {
            using (SalesERPDAL dal = new SalesERPDAL())
            {
                Employee emp =dal.Employees.Find(id);
                dal.Entry(emp).State= EntityState.Deleted;
                dal.SaveChanges();
            }
        }
        public void Update(Employee emp)
        {
            using (SalesERPDAL dal= new SalesERPDAL())
            {
                //状态修改
                dal.Entry(emp).State = EntityState.Modified;
                dal.SaveChanges();
            }
        }


    }
}