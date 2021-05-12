using Microsoft.AspNet.Identity;
using SmartTutor.Data;
using SmartTutor.Models.TutorModels;
using SmartTutor.Services.TutorServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartTutor.Controllers
{
    public class TutorController : Controller
    {

        // GET: Tutor
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        private TutorService CreateTutorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TutorService(userId);
            return service;
        }

        public ActionResult Index()
        {
            return View(_db.Tutors.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TutorCreate tutor)
        {
            if (!ModelState.IsValid)
            {
                return View(tutor);
            }
            var svc = CreateTutorService();
            if (svc.CreateTutor(tutor))
            {
                return RedirectToAction("Index");
            }
            return View(tutor);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Tutor tutor = _db.Tutors.Find(id);
            if (tutor == null)
            {
                return HttpNotFound();
            }
            return View(tutor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Tutor tutor = _db.Tutors.Find(id);
            _db.Tutors.Remove(tutor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Tutor tutor = _db.Tutors.Find(id);
            if (tutor == null)
            {
                return HttpNotFound();
            }
            return View(tutor);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tutor tutor)
        {
            if (ModelState.IsValid)
            {
                _db.Tutors.Add(tutor);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tutor);
        }

        public ActionResult Details(int? id)
        {
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                }

                Tutor tutor = _db.Tutors.Find(id);
                if (tutor == null)
                {
                    return HttpNotFound();
                }
                return View(tutor);
            }
        }
    }
}