using NIBMProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NIBMProject.Controllers
{
    public class PatientController : Controller
    {
        //
        // GET: /Patient/

        public ActionResult Index()
        {
            if (this.Session["loggedInUser"] == null || string.IsNullOrEmpty(this.Session["loggedInUser"].ToString()))
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        public ActionResult MapView()
        {
            if (this.Session["loggedInUser"] == null || string.IsNullOrEmpty(this.Session["loggedInUser"].ToString()))
            {
                return RedirectToAction("Index", "Login");
            }
            

            using (var _db = new ProjectDb())
            {
                var patients = _db.Patients.ToList();

                return View(patients);
            }

           

        }



        [HttpPost]
        public ActionResult Index(PatientModel model)
        {
            using (var _db = new ProjectDb())
            {

                //Format address
                var fullAddress = (model.Address.Contains("Sri Lanka")) ? model.Address : string.Format("{0}, Sri Lanka", model.Address);

                var position = GetLatLongFromAddress(fullAddress);
                _db.Patients.Add(
                    new Patient
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Age = model.Age,
                        Address = fullAddress,
                        DateStarted = model.DateStarted,
                        CreatedAt = DateTime.Now,
                        Lat = position.Lat,
                        Long = position.Long

                    });
                _db.SaveChanges();
                
            }
            return RedirectToAction("MapView", "Patient");

        }

        private class Position
        {
            public string Lat { get; set; }
            public string Long { get; set; }
        }

        private Position GetLatLongFromAddress(string fullAddress)
        {

            Position position = new Position();
            string strKey = "ABQIAAAASUl9uAUm3v5adeFKoLn3vxSy2FI2cjaooR640EGWHyHifvYjuhR77ueSWekJ6YnyPlre5xNSbGtURQ";
            //Create a path string with address and api key
            string sPath = "http://maps.google.com/maps/geo?q=" + fullAddress + "&output=csv&key=" + strKey;
            WebClient client = new WebClient();
            string[] eResult = client.DownloadString(sPath).ToString().Split(',');

            if (eResult.GetValue(0).ToString() != "0")
            {
                position.Lat = eResult.GetValue(2).ToString();
                position.Long = eResult.GetValue(3).ToString();

            }
            return position;
        }

       
       
    }
}
