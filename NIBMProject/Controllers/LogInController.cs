using NIBMProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NIBMProject.Controllers
{
    public class LogInController : Controller
    {
        //
        // GET: /LogIn/

        public ActionResult Index()
        {
            return View(new Login());
        }

        [HttpPost]
        public ActionResult Index(Login login)
        {
            using (var _db = new ProjectDb())
            {

                var use = _db.Userdetail
                    .Where(i => i.UserName.Equals(login.UserName) &&
                    i.Password.Equals(login.Password) && i.IsActivated == true);


                if (use.Any())
                {
                    this.Session["loggedInUser"] = login.UserName;
                    return RedirectToAction("index", "home");

                }
                else
                {
                    ModelState.AddModelError("", "That username or password does not exist.");
                }





            }

            return View();
        }

        public ActionResult Logout()
        {
            this.Session["loggedInUser"] = string.Empty;
            return RedirectToAction("index", "home");
        }
    }
}
