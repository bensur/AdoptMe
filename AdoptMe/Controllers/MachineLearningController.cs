using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdoptMe.Models;

namespace AdoptMe.Controllers
{
    public class MachineLearningController : Controller
    {
        private MachineLearningModel ml = new MachineLearningModel();
        // GET: MachineLearning
        public ActionResult Index()
        {
            return View();
        }
        // POST: MachineLearning/Decide
        [HttpPost]
        [ValidateAntiForgeryToken]
        /* Gender (Male=0,Female=1),
           Age (<18=0,18<<25=1,25<<40=2,40<=3),
           Location (Darom=0,Merkaz=1,Tzafon=2),
           Salary (<5000=0,5000<<10000=1,10000<=2)
        */
        public ActionResult Decide(string gender, double age, string location, double salary)
        {
            if ((gender != null) && gender.Equals("Male"))
                gender = "0.0";
            else
                gender = "1.0";
            if (age < 18.0)
                age = 0.0;
            else if (age < 25.0)
                age = 1.0;
            else if (age < 40.0)
                age = 2.0;
            else
                age = 3.0;
            if ((location != null) && location.Equals("Darom"))
                location = "0.0";
            else if ((location != null) && location.Equals("Merkaz"))
                location = "1.0";
            else
                location = "2.0";
            if (salary < 5000.0)
                salary = 0.0;
            else if (salary < 10000.0)
                salary = 1.0;
            else
                salary = 2.0;
            return Content(ml.Decide(new double[] { Double.Parse(gender), (double)age, Double.Parse(location), (double)salary }));
        }
    }
}