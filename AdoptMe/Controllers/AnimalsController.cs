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
    public class AnimalsController : Controller
    {
        private AnimalsContext db = new AnimalsContext();

        // GET: Animals
        public ActionResult Index()
        {
            return View(db.Animals.ToList());
        }

        // POST: Animals/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(int AnimalID, string AnimalName, string AnimalType, string AnimalBreed, string AnimalColor, string AdoptionAgencyName)
        {
            IQueryable<AnimalModel> animals = db.Animals;
            if (AnimalID != -1)
                animals = animals.Where(a => a.AnimalID == AnimalID);
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
            return View(animals.ToList());
        }

        // GET: Animals/Details/5
        public ActionResult Details(int? id)
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

        // GET: Animals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnimalID,AnimalType,AnimalBreed,AnimalColor,AnimalAge")] AnimalModel animalModel)
        {
            if (ModelState.IsValid)
            {
                db.Animals.Add(animalModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(animalModel);
        }

        // GET: Animals/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Animals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnimalID,AnimalType,AnimalBreed,AnimalColor,AnimalAge")] AnimalModel animalModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animalModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(animalModel);
        }

        // GET: Animals/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnimalModel animalModel = db.Animals.Find(id);
            db.Animals.Remove(animalModel);
            db.SaveChanges();
            return RedirectToAction("Index");
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
