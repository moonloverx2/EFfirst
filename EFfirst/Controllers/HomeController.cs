using EFfirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFfirst.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public void Add()
        {
            TestEntities dbContext = new TestEntities();
            UserInfo user = new UserInfo();
            user.Name = DateTime.Now.ToString() + "测试";
            dbContext.Entry(user).State = EntityState.Added;
            dbContext.SaveChanges();
        }

        public void Edit()
        {
            TestEntities dbContext = new TestEntities();
            UserInfo user = new UserInfo();
            user.Id = 1;
            user.Name = "修改测试";
            dbContext.Entry(user).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            TestEntities dbContext = new TestEntities();
            UserInfo user = new UserInfo();
            user.Id = id;
            dbContext.Entry(user).State = EntityState.Deleted;
            dbContext.SaveChanges();
        }

        public void Select()
        {
            TestEntities dbContext = new TestEntities();
            IQueryable<UserInfo> data = from u in dbContext.UserInfo select u;
            Response.Write("第一次执行循环<br/>");
            foreach (var m in data)
            {
                Response.Write("Id:" + m.Id + ";Name:" + m.Name + "<br/>");
            }
            Response.Write("第二次执行循环<br/>");
            foreach (var m in data)
            {
                Response.Write("Id:" + m.Id + ";Name:" + m.Name + "<br/>");
            }
        }

        public void SimSelectlately()
        {
            TestEntities dbContext = new TestEntities();
            var data = (from u in dbContext.UserInfo select u).ToList();
            Response.Write("第一次执行循环<br/>");
            foreach (var m in data)
            {
                Response.Write("Id:" + m.Id + ";Name:" + m.Name + "<br/>");
            }
            Response.Write("第二次执行循环<br/>");
            foreach (var m in data)
            {
                Response.Write("Id:" + m.Id + ";Name:" + m.Name + "<br/>");
            }
        }

        public void Selectlately()
        {
            TestEntities dbContext = new TestEntities();
            var data = (from u in dbContext.UserInfo select u).ToList();            
            foreach (var m in data)
            {
                Response.Write("Id:" + m.Id + ";Name:" + m.Name + "<br/>");
                foreach (var order in m.OrderInfo)
                {
                    Response.Write("Order Id:" + order.Id + ";Content:" + order.Content + "<br/>");
                }                
            }
           
        }

        public void SelectByPage(int page,int pagesize)
        {
            TestEntities dbContext = new TestEntities();
            var data = (from u in dbContext.UserInfo where u.Id<10 &u.Name.Contains("15:18:06") orderby u.Id descending select u).Skip(pagesize * (page -1)).Take(pagesize).ToList();
            foreach (var m in data)
            {
                Response.Write("Id:" + m.Id + ";Name:" + m.Name + "<br/>");

            }
        }

        public void SelectById(int id)
        {
            //只执行了一次sql查询
            TestEntities dbContext = new TestEntities();
            var data = dbContext.UserInfo.Find(id);
            Response.Write("Id:" + data.Id + ";Name:" + data.Name + "<br/>");
            var data1 = dbContext.UserInfo.Find(id);
            Response.Write("Id:" + data1.Id + ";Name:" + data1.Name + "<br/>");
        }

        public void SelectByLamdb(int page, int pagesize)
        {
            TestEntities dbContext = new TestEntities();
            var data = dbContext.UserInfo.Where(u => u.Id < 10).OrderByDescending(u => u.Id).Skip(pagesize * (page - 1)).Take(pagesize).ToList();
            foreach (var m in data)
            {
                Response.Write("Id:" + m.Id + ";Name:" + m.Name + "<br/>");
            }
        }
    }
}