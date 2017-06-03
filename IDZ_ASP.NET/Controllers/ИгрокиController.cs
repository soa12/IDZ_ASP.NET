using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IDZ_ASP.NET.Models;

namespace IDZ_ASP.NET.Controllers
{
    public class ИгрокиController : Controller
    {
        private DBForIDZ db = new DBForIDZ();

        // GET: Игроки
        public ActionResult Index()
        {
            var игроки = db.Игроки.Include(и => и.Персоны);
            return View(игроки.ToList());
        }

        // GET: Игроки/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Игроки игроки = db.Игроки.Find(id);
            if (игроки == null)
            {
                return HttpNotFound();
            }
            return View(игроки);
        }

        // GET: Игроки/Create
        public ActionResult Create()
        {
            ViewBag.ID_персоны = new SelectList(db.Персоны, "ID_персоны", "Фамилия");
            return View();
        }

        // POST: Игроки/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_персоны")] Игроки игроки)
        {
            if (ModelState.IsValid)
            {
                игроки.ID_персоны = Guid.NewGuid();
                db.Игроки.Add(игроки);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_персоны = new SelectList(db.Персоны, "ID_персоны", "Фамилия", игроки.ID_персоны);
            return View(игроки);
        }

        // GET: Игроки/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Игроки игроки = db.Игроки.Find(id);
            if (игроки == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_персоны = new SelectList(db.Персоны, "ID_персоны", "Фамилия", игроки.ID_персоны);
            return View(игроки);
        }

        // POST: Игроки/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_персоны")] Игроки игроки)
        {
            if (ModelState.IsValid)
            {
                db.Entry(игроки).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_персоны = new SelectList(db.Персоны, "ID_персоны", "Фамилия", игроки.ID_персоны);
            return View(игроки);
        }

        // GET: Игроки/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Игроки игроки = db.Игроки.Find(id);
            if (игроки == null)
            {
                return HttpNotFound();
            }
            return View(игроки);
        }

        // POST: Игроки/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Игроки игроки = db.Игроки.Find(id);
            db.Игроки.Remove(игроки);
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
