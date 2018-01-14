using SignalRRealTime.Manager;
using SignalRRealTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRRealTime.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext dbcontext = new DatabaseContext();
        public ActionResult Index()
        {
            List<Worker> workers = dbcontext.Workers.ToList();

            return View(workers);
        }
        public ActionResult Create()
        {
            return View(new Worker());
        }
        //[HttpPost]
        //public ActionResult Create(Worker work)
        //{
        //    Worker wrk = new Worker()
        //    {
        //        Name = work.Surname,
        //        Surname = work.Surname,
        //        UserName = work.UserName
        //    };
        //    dbcontext.Workers.Add(wrk);
        //    dbcontext.SaveChanges();
        //    return View();
        //}


    }
}