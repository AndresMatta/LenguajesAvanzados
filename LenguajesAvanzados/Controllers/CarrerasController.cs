using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LenguajesAvanzados.Models;

namespace LenguajesAvanzados.Controllers
{
    public class CarrerasController : Controller
    {
        private LAContext db = new LAContext();

        // GET: Carreras
        public async Task<ActionResult> Index()
        {
            var carreras = db.Carreras.Include(c => c.Universidad);
            return View(await carreras.ToListAsync());
        }

        // GET: Carreras/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrera carrera = await db.Carreras.FindAsync(id);
            if (carrera == null)
            {
                return HttpNotFound();
            }
            return View(carrera);
        }

        // GET: Carreras/Create
        public ActionResult Create()
        {
            ViewBag.UniversidadId = new SelectList(db.Universidades, "ID", "Nombre");
            return View();
        }

        // POST: Carreras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,UniversidadId,Nombre")] Carrera carrera)
        {
            if (ModelState.IsValid)
            {
                db.Carreras.Add(carrera);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UniversidadId = new SelectList(db.Universidades, "ID", "Nombre", carrera.UniversidadId);
            return View(carrera);
        }

        // GET: Carreras/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrera carrera = await db.Carreras.FindAsync(id);
            if (carrera == null)
            {
                return HttpNotFound();
            }
            ViewBag.UniversidadId = new SelectList(db.Universidades, "ID", "Nombre", carrera.UniversidadId);
            return View(carrera);
        }

        // POST: Carreras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,UniversidadId,Nombre")] Carrera carrera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrera).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UniversidadId = new SelectList(db.Universidades, "ID", "Nombre", carrera.UniversidadId);
            return View(carrera);
        }

        // GET: Carreras/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrera carrera = await db.Carreras.FindAsync(id);
            if (carrera == null)
            {
                return HttpNotFound();
            }
            return View(carrera);
        }

        // POST: Carreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Carrera carrera = await db.Carreras.FindAsync(id);
            db.Carreras.Remove(carrera);
            await db.SaveChangesAsync();
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
