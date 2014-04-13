using NIBMProject.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

	

namespace NIBMProject.Controllers
{
    public class RegisterController : Controller
    {
        //
        // GET: /Register/
        ProjectDb _db = new ProjectDb();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Register reg)
        {
            if (ModelState.IsValid)
            {
                var user = _db.Userdetail.Where(i => i.Email.Equals(reg.Email));

                if (user.Any())
                {
                    ModelState.AddModelError("", "this email been defined");
                }
                else
                {

                    var userId = Guid.NewGuid();

                    _db.Userdetail.Add(
                        new UserDetails
                        {
                            id = userId,
                            UserName = reg.UserName,
                            Password = reg.Password,
                            IsActivated = false,
                            Email = reg.Email,
                        }
                        );
                    _db.SaveChanges();
                    SendActivationEmail(reg.Email, userId);
                    return RedirectToAction("index", "logIn");





                }
            }
            return View();
        }


        private void SendActivationEmail(string email, Guid userId)
        {
            SmtpClient gmailClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential("madusanka.lk@gmail.com", "p")
            };
            string message = "Click this link to activate your account <a href=http://localhost:38654/ActivateUser/?userId=" + userId.ToString() + ">Activate</a>";

            var mailMessage = new MailMessage("info@test.com", email, "Activation Email", message);
            gmailClient.Send(mailMessage);
        }

    }
}
