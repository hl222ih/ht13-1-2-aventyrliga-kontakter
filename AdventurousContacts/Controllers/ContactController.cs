using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdventurousContacts.Models;

namespace AdventurousContacts.Controllers
{
    public class ContactController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Contact/

        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View(db.Contact.ToList());
        }

        //
        // GET: /Contact/Details/5

        public ActionResult Details(int id = 0)
        {
            Contact contact = db.Contact.Find(id);
            if (contact == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(contact);
        }

        //
        // GET: /Contact/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Contact/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contact.Add(contact);
                try
                {
                    db.SaveChanges();
                    TempData["Message"] = "Kontakten har skapats.";
                    return RedirectToAction("Index");
                }
                catch
                {
                    TempData["Message"] = "Kontakten kunde inte skapas.";                    
                }
            }

            return View(contact);
        }

        //
        // GET: /Contact/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Contact contact = db.Contact.Find(id);
            if (contact == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(contact);
        }

        //
        // POST: /Contact/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                    TempData["Message"] = "Kontakten har uppdaterats.";
                    return RedirectToAction("Index");
                }
                catch
                {
                    TempData["Message"] = "Kontakten kunde inte uppdateras.";
                }
            }
            return View(contact);
        }

        //
        // GET: /Contact/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Contact contact = db.Contact.Find(id);
            if (contact == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(contact);
        }

        //
        // POST: /Contact/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contact.Find(id);
            db.Contact.Remove(contact);
            try
            {
                db.SaveChanges();
                TempData["Message"] = "Kontakten har raderats.";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Kontakten kunde inte raderas.";                
            }
            return View(contact);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}