using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModels;
using WebApplication1.Models;
using WebApplication1.DataAccessLayer;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeListViewModel empListModel = new EmployeeListViewModel();
            //获取将处理过的数据列表
            empListModel.EmployeeViewList =getEmpVmList();
            // 获取问候语
            empListModel.Greeting = getGreeting();
            //获取用户名
            empListModel.UserName = getUserName();
            //将数据送往视图
            return View(empListModel);
        }
        /// <summary>
        /// 获取新增的行为
        /// </summary>
        /// <returns></returns>
        public ActionResult AddNew() {
            return View("CreateEmployee");
        }
        public ActionResult Update(int id)
        {
            ViewBag.id = id;
            EmployeeBusinessLayer eve = new EmployeeBusinessLayer();
            Employee emp= eve.Query(id);
            return View("AlterEmployee", emp);
        }
        public ActionResult Inquire(string searchString)
        {
            EmployeeBusinessLayer eve = new EmployeeBusinessLayer();
            var emps=eve.Querys(searchString);
            return View(emps);
        }

        public ActionResult Save(Employee emp)
        {
            //string name=emp.Name;
            //int salary=emp.Salary;
            EmployeeBusinessLayer eve = new EmployeeBusinessLayer();
            eve.Add(emp);
            return new RedirectResult("index");
        }
        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer eve = new EmployeeBusinessLayer();
            eve.Delete(id);
            return RedirectToAction("index");
        }
        public ActionResult Updates(Employee emp)
        {
            EmployeeBusinessLayer eve = new EmployeeBusinessLayer();

            eve.Update(emp);
            return RedirectToAction("index");
        }

        [NonAction]
        List<EmployeeViewModel> getEmpVmList()
        {
            //实例化员工信息业务层
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            //员工原始数据列表，获取来自业务层类的数据
            var listEmp = empBL.GetEmployeeList();
            //员工原始数据加工后的视图数据列表，当前状态是空的
            var listEmpVm = new List<EmployeeViewModel>();

            //通过循环遍历员工原始数据数组，将数据一个一个的转换，并加入listEmpVm
            foreach (var item in listEmp)
            {
                //实例EmployeeViewModel的类
                EmployeeViewModel empVmObj = new EmployeeViewModel();
                empVmObj.EmployeeID = item.EmployeeID;
                empVmObj.EmployeeName = item.Name;
                //将工资的int转成String 货币化  加到实例EmployeeViewModel的类
                empVmObj.EmployeeSalary = item.Salary.ToString("C");
                if (item.Salary > 10000)
                {
                    empVmObj.EmployeeGrade = "不错";
                }
                else
                {
                    empVmObj.EmployeeGrade = "加油";
                }

                listEmpVm.Add(empVmObj);
            }

            return listEmpVm;

        }

        [NonAction]
        string getGreeting()
        {
            string greeting;
            //获取当前时间
            DateTime dt = DateTime.Now;
            //获取当前小时数
            int hour = dt.Hour;
            //根据小时数判断需要返回哪个视图，<12 返回myview 否则返回 yourview
            if (hour < 12)
            {
                greeting = "早上好";
            }
            else
            {
                greeting = "下午好";
            }
            return greeting;
        }

        [NonAction]
        string getUserName()
        {
            return "Admin";
        }
    }
}