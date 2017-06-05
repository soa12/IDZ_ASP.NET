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
    public class Контракт_игрока_с_клубомController : Controller
    {
        private FootballDB db = new FootballDB();

        // GET: Контракт_игрока_с_клубом
        public ActionResult Index()
        {

            List<КонтрактИгрокаМодель> КонтрактИгрока = db.Контракт_игрока_с_клубом
                .Include(к => к.Игроки.Персоны).Include(к => к.Клубы).Include(к => к.Позиции_игроков)
                .Select(
                    к => new КонтрактИгрокаМодель
                    {
                        ID_контракта = к.ID_контракта,
                        Игрок = к.Игроки.Персоны.Имя+" "+к.Игроки.Персоны.Фамилия,
                        Клуб = к.Клубы.Название,
                        Позиция = к.Позиции_игроков.Название,
                        Номер_на_поле = к.Номер_на_поле,
                        Дата_начала = к.Дата_начала,
                        Дата_окончания = к.Дата_окончания

                    })
                .ToList();
            return View(КонтрактИгрока);
        }

        // GET: Контракт_игрока_с_клубом/Details/5
        public ActionResult Details(Guid? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Контракт_игрока_с_клубом контракт_игрока_с_клубом = db.Контракт_игрока_с_клубом.Find(id);
            if (контракт_игрока_с_клубом == null)
            {
                return HttpNotFound();
            }
            return View(контракт_игрока_с_клубом);
        }

        // GET: Контракт_игрока_с_клубом/Create
        public ActionResult Create()
        {
            var КонтрактИгрока = new ИзменениеКонтрактИгрока
            {
                СписокИгроков = db.Игроки.ToList()
                    .Select(и => new SelectListItem()
                    {
                        Text = и.Персоны.Имя + " " + и.Персоны.Фамилия,
                        Value = и.ID_персоны.ToString()
                    })
                    .ToList(),
                СписокКлубов = db.Клубы.ToList()
                    .Select(к => new SelectListItem()
                    {
                        Text = к.Название,
                        Value = к.ID_клуба.ToString()
                    })
                    .ToList(),
                СписокПозиций = db.Позиции_игроков.ToList()
                    .Select(п => new SelectListItem()
                    {
                        Text = п.Название,
                        Value = п.ID_позиции.ToString()
                    })
                    .ToList()

            };
            return View(КонтрактИгрока);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ИзменениеКонтрактИгрока Контракт)
        {

            var новыйКонтракт = new Контракт_игрока_с_клубом
            {
                ID_контракта = Guid.NewGuid(),
                Дата_начала = Контракт.Дата_начала,
                Дата_окончания = Контракт.Дата_окончания,
                Номер_на_поле = Контракт.Номер_на_поле,
                ID_персоны = Контракт.ID_персоны,
                ID_клуба = Контракт.ID_клуба,
                ID_позиции = Контракт.ID_позиции
            };
            db.Контракт_игрока_с_клубом.Add(новыйКонтракт);
            db.SaveChanges();
            return RedirectToAction("Index");          
        }

        public ActionResult Edit(Guid? id)
        {         
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var контракт_игрока_с_клубом = db.Контракт_игрока_с_клубом.Find(id);
            List<SelectListItem> СписокИгроковБД = db.Игроки.ToList()
                .Select(и => new SelectListItem()
                {
                    Text = и.Персоны.Имя + " " + и.Персоны.Фамилия,
                    Value = и.ID_персоны.ToString(),
                    Selected = и.ID_персоны == контракт_игрока_с_клубом.ID_персоны
                })
                .ToList();
            List<SelectListItem> СписокКлубовБД = db.Клубы.ToList()
                .Select(к => new SelectListItem()
                {
                    Text = к.Название,
                    Value = к.ID_клуба.ToString(),
                    Selected = к.ID_клуба == контракт_игрока_с_клубом.ID_клуба

                })
                .ToList();
            List<SelectListItem> СписокПозицийБД = db.Позиции_игроков.ToList()
                .Select(п => new SelectListItem()
                {
                    Text = п.Название,
                    Value = п.ID_позиции.ToString(),
                    Selected = п.ID_позиции == контракт_игрока_с_клубом.ID_позиции
                })
                .ToList();
            
            var контрактИгрока = new ИзменениеКонтрактИгрока
            {
                ID_контракта = контракт_игрока_с_клубом.ID_контракта,
                ID_игрока = контракт_игрока_с_клубом.ID_персоны,
                ID_клуба = контракт_игрока_с_клубом.ID_клуба,
                ID_позиции = контракт_игрока_с_клубом.ID_позиции,
                Дата_начала = контракт_игрока_с_клубом.Дата_начала,
                Дата_окончания = контракт_игрока_с_клубом.Дата_окончания,
                Номер_на_поле = контракт_игрока_с_клубом.Номер_на_поле,
                СписокИгроков = СписокИгроковБД,
                СписокКлубов = СписокКлубовБД,
                СписокПозиций = СписокПозицийБД
            };
            if (контракт_игрока_с_клубом == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Игроки = new SelectList(db.Игроки.Include(и => и.Персоны), "ID_персоны", "Игрок", ИзменениеКонтрактИгрока.ID_персоны);
            //ViewBag.Клубы = new SelectList(db.Клубы, "ID_клуба", "Название", ИзменениеКонтрактИгрока.ID_клуба);
            //ViewBag.Позиции = new SelectList(db.Позиции_игроков, "ID_позиции", "Название", ИзменениеКонтрактИгрока.ID_позиции);
            return View(контрактИгрока);
            
           

        }

        // POST: Контракт_игрока_с_клубом1/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ИзменениеКонтрактИгрока контрактИгрока)
        {
            var контракт_игрока_с_клубом = db.Контракт_игрока_с_клубом.Find(контрактИгрока.ID_контракта);
            контракт_игрока_с_клубом.ID_контракта = контрактИгрока.ID_контракта;
            контракт_игрока_с_клубом.ID_клуба = контрактИгрока.ID_клуба;
            //контракт_игрока_с_клубом.ID_персоны = контрактИгрока.ID_персоны;
            контракт_игрока_с_клубом.Дата_начала = контрактИгрока.Дата_начала;
            контракт_игрока_с_клубом.Дата_окончания = контрактИгрока.Дата_окончания;
            контракт_игрока_с_клубом.Номер_на_поле = контрактИгрока.Номер_на_поле;
            контракт_игрока_с_клубом.ID_позиции = контрактИгрока.ID_позиции;
            if (ModelState.IsValid)
            {
                db.Entry(контракт_игрока_с_клубом).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.ID_персоны = new SelectList(db.Игроки, "ID_персоны", "ID_персоны", контракт_игрока_с_клубом.ID_персоны);
           // ViewBag.ID_клуба = new SelectList(db.Клубы, "ID_клуба", "Название", контракт_игрока_с_клубом.ID_клуба);
            //ViewBag.ID_позиции = new SelectList(db.Позиции_игроков, "ID_позиции", "Название", контракт_игрока_с_клубом.ID_позиции);
            return View(контрактИгрока);
        }

        // GET: Контракт_игрока_с_клубом1/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Контракт_игрока_с_клубом контракт_игрока_с_клубом = db.Контракт_игрока_с_клубом.Find(id);
            if (контракт_игрока_с_клубом == null)
            {
                return HttpNotFound();
            }
            return View(контракт_игрока_с_клубом);
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
