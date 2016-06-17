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

        public void SelectByPage(int page)
        {
            TestEntities dbContext = new TestEntities();
            var data = (from u in dbContext.UserInfo orderby u.Id descending select u).Skip(2*(page -1)).Take(2).ToList();
            foreach (var m in data)
            {
                Response.Write("Id:" + m.Id + ";Name:" + m.Name + "<br/>");

            }
        }


    }
}