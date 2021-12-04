using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment2.Models;

namespace Assignment2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult RegisteredUser()
        {
            UserDBcontext db = new UserDBcontext();
            List<User> obj = db.GetUsers();
            return View(obj);
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User us)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    UserDBcontext context = new UserDBcontext();
                    bool check = context.AddUsers(us);
                    if (check == true)
                    {
                        TempData["InsertMessage"] = "You've registered successfully!";
                        ModelState.Clear();
                        return RedirectToAction("RegisteredUser");
                    }
                }
                return View();
            }
            catch
            {
                return View();

            }
        }

        public ActionResult Update(int id)
        {
            UserDBcontext context = new UserDBcontext();
            var row = context.GetUsers().Find(model => model.id == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Update(int id, User us)
        {
            if (ModelState.IsValid == true)
            {
                UserDBcontext context = new UserDBcontext();
                bool check = context.UpdateUsers(us);
                if (check == true)
                {
                    TempData["UpdateMessage"] = "You've updated your data successfully!";
                    ModelState.Clear();
                    return RedirectToAction("RegisteredUser");
                }
            }
            return View();
        }

        public ActionResult Profile(int id)
        {
            UserDBcontext context = new UserDBcontext();
            var row = context.GetUsers().Find(model => model.id == id);
            return View(row);
        }

        public ActionResult Delete(int id)
        {
            UserDBcontext context = new UserDBcontext();
            var row = context.GetUsers().Find(model => model.id == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(int id, User us)
        {
            UserDBcontext context = new UserDBcontext();
            bool check = context.DeleteUsers(id);
            if (check == true)
            {
                TempData["DeleteMessage"] = "You've deleted your data successfully!";
                ModelState.Clear();
                return RedirectToAction("RegisteredUser");
            }
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "This is simple login & registration application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "You can contact below mentioned: ";

            return View();
        }
    }
}