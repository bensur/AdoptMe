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
        public ActionResult Decide(string gender, int age, string location, int salary)
        {
            if (gender.Equals("Male"))
                gender = "0";
            else
                gender = "1";
            if (age < 18)
                age = 0;
            else if (age < 25)
                age = 1;
            else if (age < 40)
                age = 2;
            else
                age = 3;
            if (location.Equals("Darom"))
                location = "0";
            else if (location.Equals("Merkaz"))
                location = "1";
            else
                location = "2";
            if (salary < 5000)
                salary = 0;
            else if (salary < 10000)
                salary = 1;
            else
                salary = 2;
            return Content(ml.Decide(new double[] { Double.Parse(gender), (double)age, Double.Parse(location), (double)salary }));
        }
    }
}