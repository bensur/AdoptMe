using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdoptMe.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AdoptMe.Controllers
{
    public class AnimalsController : Controller
    {
        private AnimalsContext db = new AnimalsContext();
        // GET: Animals
        public ActionResult Index()
        {
            ViewBag.AdoptionAgencies = db.AdoptionAgencies.ToList();
            ViewBag.Animals = db.Animals.ToList();
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.userName = user.Name;
                ViewBag.isUserAdmin = false;
                if (isAdminUser())
                {
                    ViewBag.isUserAdmin = true;
                }
                return View();
            }
            else
            {
                ViewBag.userName = "Not Logged IN";
            }
            return View();

        }

        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext usersContext = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(usersContext));
                var s = UserManager.GetRoles(user.GetUserId());
                if ((s.Count > 0) && (s[0].ToString().Equals("Admin")))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        // POST: Animals/SearchAnimals
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult SearchAnimals(string AnimalName, string AnimalType, string AnimalBreed, string AnimalColor, string AdoptionAgencyName)
        {
            IQueryable<AnimalModel> animals = db.Animals;
            if (!String.IsNullOrEmpty(AnimalName))
                animals = animals.Where(a => a.AnimalName.ToLower().Contains(AnimalName.ToLower()));
            if (!String.IsNullOrEmpty(AnimalType))
                animals = animals.Where(a => a.AnimalType.ToLower().Contains(AnimalType.ToLower()));
            if (!String.IsNullOrEmpty(AnimalBreed))
                animals = animals.Where(a => a.AnimalBreed.ToLower().Contains(AnimalBreed.ToLower()));
            if (!String.IsNullOrEmpty(AnimalColor))
                animals = animals.Where(a => a.AnimalColor.ToLower().Contains(AnimalColor.ToLower()));
            if (!String.IsNullOrEmpty(AdoptionAgencyName))
                animals = animals.Where(a => a.AnimalAdoptionAgency.AdoptionAgencyName.ToLower().Contains(AdoptionAgencyName.ToLower()));
            ViewBag.Animals = animals.ToList();
            return PartialView();
        }

        // POST: Animals/SearchAdoptionAgencies
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult SearchAdoptionAgencies(string AdoptionAgencyName)
        {
            IQueryable<AdoptionAgencyModel> adoptionAgenceis = db.AdoptionAgencies;
            if (!String.IsNullOrEmpty(AdoptionAgencyName))
                adoptionAgenceis = adoptionAgenceis.Where(a => a.AdoptionAgencyName.ToLower().Contains(AdoptionAgencyName.ToLower()));
            ViewBag.AdoptionAgencies = adoptionAgenceis.ToList();
            return PartialView();
        }

        // GET: Animals/AnimalDetails/5
        public ActionResult AnimalDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalModel animalModel = db.Animals.Find(id);
            if (animalModel == null)
            {
                return HttpNotFound();
            }
            return View(animalModel);
        }

        // GET: Animals/AdoptionAgencyDetails/5
        public ActionResult AdoptionAgencyDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdoptionAgencyModel adoptionAgencyModel = db.AdoptionAgencies.Find(id);
            if (adoptionAgencyModel == null)
            {
                return HttpNotFound();
            }
            return View(adoptionAgencyModel);
        }

        // GET: Animals/CreateAnimal
        public ActionResult CreateAnimal()
        {
            return View();
        }

        // POST: Animals/CreateAnimal
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAnimal([Bind(Include = "AnimalID,AnimalName,AnimalType,AnimalBreed,AnimalColor,AnimalAge,AnimalAgencyName")] AnimalModel animalModel)
        {
            if (!String.IsNullOrEmpty(animalModel.AnimalAgencyName))
                animalModel.AnimalAdoptionAgency = db.AdoptionAgencies.FirstOrDefault(agency => agency.AdoptionAgencyName.Equals(animalModel.AnimalAgencyName));
            if (ModelState.IsValid)
            {
                db.Animals.Add(animalModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(animalModel);
        }

        // GET: Animals/CreateAdoptionAgency
        public ActionResult CreateAdoptionAgency()
        {
            return View();
        }

        // POST: Animals/CreateAdoptionAgency
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAdoptionAgency([Bind(Include = "AdoptionAgencyID,AdoptionAgencyName,AdoptionAgencyLocationLat,AdoptionAgencyLocationLng")] AdoptionAgencyModel adoptionAgencyModel)
        {
            if (ModelState.IsValid)
            {
                db.AdoptionAgencies.Add(adoptionAgencyModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adoptionAgencyModel);
        }

        // GET: Animals/EditAnimal/5
        public ActionResult EditAnimal(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalModel animalModel = db.Animals.Find(id);
            if (animalModel == null)
            {
                return HttpNotFound();
            }
            return View(animalModel);
        }

        // POST: Animals/EditAnimal/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAnimal([Bind(Include = "AnimalID,AnimalType,AnimalBreed,AnimalColor,AnimalAge")] AnimalModel animalModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animalModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(animalModel);
        }

        // GET: Animals/EditAdoptionAgency/5
        public ActionResult EditAdoptionAgency(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdoptionAgencyModel adoptionAgencyModel = db.AdoptionAgencies.Find(id);
            if (adoptionAgencyModel == null)
            {
                return HttpNotFound();
            }
            return View(adoptionAgencyModel);
        }

        // POST: Animals/EditAdoptionAgency/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAdoptionAgency([Bind(Include = "AdoptionAgencyID,AdoptionAgencyName,AdoptionAgencyLocationLat,AdoptionAgencyLocationLng")] AdoptionAgencyModel adoptionAgencyModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adoptionAgencyModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adoptionAgencyModel);
        }

        // GET: Animals/DeleteAnimal/5
        public ActionResult DeleteAnimal(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalModel animalModel = db.Animals.Find(id);
            if (animalModel == null)
            {
                return HttpNotFound();
            }
            return View(animalModel);
        }

        // POST: Animals/DeleteAnimal/5
        [HttpPost, ActionName("DeleteAnimal")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnimalModel animalModel = db.Animals.Find(id);
            db.Animals.Remove(animalModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Animals/DeleteAdoptionAgency/5
        public ActionResult DeleteAdoptionAgency(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdoptionAgencyModel adoptionAgencyModel = db.AdoptionAgencies.Find(id);
            if (adoptionAgencyModel == null)
            {
                return HttpNotFound();
            }
            return View(adoptionAgencyModel);
        }

        // POST: Animals/DeleteAdoptionAgency/5
        [HttpPost, ActionName("DeleteAdoptionAgency")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAgencyConfirmed(int id)
        {
            AdoptionAgencyModel adoptionAgencyModel = db.AdoptionAgencies.Find(id);
            db.AdoptionAgencies.Remove(adoptionAgencyModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET Anumals/AnimalsStatistics
        public ActionResult AnimalsStatistics()
        {
            return View();
        }

        // GET: Animals/GetAgenciesStatistics
        public JsonResult GetAgenciesStatistics()
        {
            return Json(db.AdoptionAgencies.GroupJoin(db.Animals, adoptionAgency => adoptionAgency, animal => animal.AnimalAdoptionAgency, (adoptionAgency, animalsCollection) => new { label = adoptionAgency.AdoptionAgencyName, count = animalsCollection.Count() }).ToList(), JsonRequestBehavior.AllowGet);
        }

        // GET: Animals/GetAnimalsStatistics
        public JsonResult GetAnimalsStatistics()
        {
            return Json(db.Animals.GroupBy(a => a.AnimalType).Select(g => new { type = g.Key, frequency = g.Count()}).ToList(), JsonRequestBehavior.AllowGet);
        }

        
    	protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
