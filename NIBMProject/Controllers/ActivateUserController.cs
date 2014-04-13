using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NIBMProject.Models;

namespace NIBMProject.Controllers
{
    public class ActivateUserController : Controller
    {
        //
        // GET: /ActivateUser/

        public ActionResult Index(string userId)
        {
            var name = string.Empty;
            using (var _db = new ProjectDb())
            {

                var UserId = Guid.Parse(userId);
                var login = _db.Userdetail
                        .Single(i => i.id == UserId);

                if (login != null)
                {
                    login.IsActivated = true;
                    _db.SaveChanges();
                }


                name = login.UserName;


                return RedirectToAction("index", "login");

            }
            //ViewBag.Name = name;


        }
    }
}
