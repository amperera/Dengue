using NIBMProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace NIBMProject.Controllers
{
    public class ChangePasswordController : Controller
    {
        //
        // GET: /ChangePassword/

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(ForgotPassword forgot)
        {
            using (var _db = new ProjectDb())
            {

                var user = _db.Userdetail
                    .Where(i => i.Email.Equals(forgot.Email)).SingleOrDefault();

                if (user != null)
                {
                    SendActivationEmail(forgot.Email, user.id, user.Password);
                    user.IsActivated = false;
                    _db.SaveChanges();
                    return RedirectToAction("index", "login");
                }
                else
                {
                    ModelState.AddModelError("", "Email is not found");
                    return View(forgot);
                }

            }


            //return View();
        }


        private void SendActivationEmail(string email, Guid userId, string pswd)
        {
            SmtpClient gmailClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential("madusanka.lk@gmail.com", "aaa")
            };

            string message = "Click this link reactivate your account <a href=http://localhost:38654/ActivateUser/?userId=" + userId.ToString() + ">Activate</a> your password is" + pswd;

            var mailMessage = new MailMessage("info@test.com", email, "Activation Email", message);
            gmailClient.Send(mailMessage);
        }

    }
}
