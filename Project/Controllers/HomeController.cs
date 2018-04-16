using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            return RedirectToAction("Login");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(User Tb)
        {
            if (ModelState.IsValid)
            {
                using (Database1Entities db = new Database1Entities ())
                {

                    db.Users.Add(Tb);
                    db.SaveChanges();


                    ModelState.Clear();
                    Tb = null;
                    ViewBag.Message = "Registration Successful";
                }


            }
            return View();
        }

        public ActionResult HelpRegistration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HelpRegistration(Help Tb)
        {
            if (ModelState.IsValid)
            {
                using (Database1Entities1 db = new Database1Entities1())
                {

                    db.Helps.Add(Tb);
                    db.SaveChanges();


                    ModelState.Clear();
                    Tb = null;
                    ViewBag.Message = "Registration Successful";
                }


            }
            return View();
        }

        public ActionResult MemberList(User tb)
        {
            using (Database1Entities db = new Database1Entities())
            {

                return View(db.Users.ToList());
            }


            return View();
        }

        public ActionResult HelpList(Help tb)
        {
            using (Database1Entities1 db = new Database1Entities1())
            {

                return View(db.Helps.ToList());
            }


            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            using (Database1Entities dc = new Database1Entities())
            {

                var usr = dc.Users.Single(u => u.Email == user.Email && u.Password == user.Password);

                if (usr != null)
                {
                    Session["UserId"] = usr.Id.ToString();
                    Session["UserName"] = usr.UserName.ToString();
                    Session["FullName"] = usr.FullName.ToString();
                    Session["Email"] = usr.Email.ToString();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "UserName or Password is wrong");
                }

            }
            return View();
        }

       

       

       public ActionResult AddEvent()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEvent(Event ev)
        {

            if (ModelState.IsValid)
            {
                using (Database1Entities1 db = new Database1Entities1())
                {

                    db.Events.Add(ev);
                    db.SaveChanges();


                    ModelState.Clear();
                    ev = null;
                    ViewBag.Message = "Registration Successful";
                }


            }
            return View();

        }
        public ActionResult ShowEvent(Event tb)
        {
            using (Database1Entities1 db = new Database1Entities1())
            {

                return View(db.Events.ToList());
            }


            return View();
        }

        public ActionResult Payment()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Payment(Payment Tb)
        {
            if (ModelState.IsValid)
            {
                using (Database1Entities2 db = new Database1Entities2())
                {

                    db.Payments.Add(Tb);
                    db.SaveChanges();


                    ModelState.Clear();
                    Tb = null;
                    ViewBag.Message = "Registration Successful";
                }


            }
            return View();
        }

        public ActionResult PayHistory(Payment pay)
        {
            using (Database1Entities2 db = new Database1Entities2())
            {

                return View(db.Payments.ToList());
            }


            return View();
        }
    }
}