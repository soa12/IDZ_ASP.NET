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
    public class ПерсоныController : Controller
    {
        private FootballDB db = new FootballDB();

        // GET: Персоны
        public ActionResult Index()
        {
            //var персоны = db.Персоны.Include(п => п.Государство);//.Include(п => п.Игроки).Include(п => п.Тренеры);
            //return View(персоны.ToList());

            List<ПерсоныМодель> Персоны = db.Персоны
                .Include(п => п.Государство)
                .Select(
                    п => new ПерсоныМодель
                    {
                        ID_персоны = п.ID_персоны,
                        Фамилия = п.Фамилия,
                        Имя = п.Имя,
                        Отчество = п.Отчество,
                        Дата_рождения = п.Дата_рождения,
                        Рост = п.Рост,
                        Вес = п.Вес,
                        Гражданство = п.Гражданство,
                        Страна = п.Государство.Наименование

                    })
                .ToList();
            return View(Персоны);
        }

        // GET: Персоны/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Персоны персоны = db.Персоны.Find(id);
            if (персоны == null)
            {
                return HttpNotFound();
            }
            return View(персоны);
        }

        // GET: Персоны/Create
        public ActionResult Create()
        {
            ViewBag.Гражданство = new SelectList(db.Государство, "ID_государства", "Наименование");
            //ViewBag.ID_персоны = new SelectList(db.Игроки, "ID_персоны", "ID_персоны");
            //ViewBag.ID_персоны = new SelectList(db.Тренеры, "ID_персоны", "ID_персоны");
            return View();
        }

        // POST: Персоны/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_персоны,Фамилия,Имя,Отчество,Дата_рождения,Рост,Вес,Гражданство")] Персоны персоны)
        {
            if (ModelState.IsValid)
            {
                персоны.ID_персоны = Guid.NewGuid();
                db.Персоны.Add(персоны);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Гражданство = new SelectList(db.Государство, "ID_государства", "Наименование", персоны.Гражданство);
            //ViewBag.ID_персоны = new SelectList(db.Игроки, "ID_персоны", "ID_персоны", персоны.ID_персоны);
            //ViewBag.ID_персоны = new SelectList(db.Тренеры, "ID_персоны", "ID_персоны", персоны.ID_персоны);
            return View(персоны);
        }

        // GET: Персоны/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Персоны персоны = db.Персоны.Find(id);
            if (персоны == null)
            {
                return HttpNotFound();
            }
            ViewBag.Гражданство = new SelectList(db.Государство, "ID_государства", "Наименование", персоны.Гражданство);
            //ViewBag.ID_персоны = new SelectList(db.Игроки, "ID_персоны", "ID_персоны", персоны.ID_персоны);
            //ViewBag.ID_персоны = new SelectList(db.Тренеры, "ID_персоны", "ID_персоны", персоны.ID_персоны);
            return View(персоны);
        }

        // POST: Персоны/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_персоны,Фамилия,Имя,Отчество,Дата_рождения,Рост,Вес,Гражданство")] Персоны персоны)
        {
            if (ModelState.IsValid)
            {
                db.Entry(персоны).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Гражданство = new SelectList(db.Государство, "ID_государства", "Наименование", персоны.Гражданство);
           //ViewBag.ID_персоны = new SelectList(db.Игроки, "ID_персоны", "ID_персоны", персоны.ID_персоны);
            //ViewBag.ID_персоны = new SelectList(db.Тренеры, "ID_персоны", "ID_персоны", персоны.ID_персоны);
            return View(персоны);
        }

        // GET: Персоны/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Персоны персоны = db.Персоны.Find(id);
            if (персоны == null)
            {
                return HttpNotFound();
            }
            return View(персоны);
        }

        // POST: Персоны/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Персоны персоны = db.Персоны.Find(id);
            db.Персоны.Remove(персоны);
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
