using Microsoft.AspNet.Identity;
using SmartTutor.Data;
using SmartTutor.Models.SubjectModels;
using SmartTutor.Services.SubjectServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartTutor.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private SubjectService CreateSubjectService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SubjectService(userId);
            return service;
        }

        public ActionResult Index()
        {
            return View(_db.Subjects.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SubjectCreate subject)
        {
            if (!ModelState.IsValid)
            {
                return View(subject);
            }
            var svc = CreateSubjectService();
            if (svc.CreateSubject(subject))
            {
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Subject subject = _db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Subject subject = _db.Subjects.Find(id);
            _db.Subjects.Remove(subject);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Subject subject = _db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubjectEdit subject)
        {
            if (ModelState.IsValid)
            {
                var svc = CreateSubjectService();
                if (svc.UpdateSubject(subject))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(subject);
        }

        public ActionResult Details(int? id)
        {
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                }

                Subject subject = _db.Subjects.Find(id);
                if (subject == null)
                {
                    return HttpNotFound();
                }
                return View(subject);
            }
        }
    }
}