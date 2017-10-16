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
    public class AsignaturasController : Controller
    {
        private LAContext db = new LAContext();

        // GET: Asignaturas
        public async Task<ActionResult> Index()
        {
            var asignaturas = db.Asignaturas.Include(a => a.Carrera).Include(a => a.Profesor);
            return View(await asignaturas.ToListAsync());
        }

        // GET: Asignaturas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignatura asignatura = await db.Asignaturas.FindAsync(id);
            if (asignatura == null)
            {
                return HttpNotFound();
            }
            return View(asignatura);
        }

        // GET: Asignaturas/Create
        public ActionResult Create()
        {
            ViewBag.CarreraId = new SelectList(db.Carreras, "ID", "Nombre");
            ViewBag.ProfesorId = new SelectList(db.Profesores, "ID", "Cedula");
            return View();
        }

        // POST: Asignaturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,CarreraId,ProfesorId,Nombre")] Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                db.Asignaturas.Add(asignatura);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CarreraId = new SelectList(db.Carreras, "ID", "Nombre", asignatura.CarreraId);
            ViewBag.ProfesorId = new SelectList(db.Profesores, "ID", "Cedula", asignatura.ProfesorId);
            return View(asignatura);
        }

        // GET: Asignaturas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignatura asignatura = await db.Asignaturas.FindAsync(id);
            if (asignatura == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarreraId = new SelectList(db.Carreras, "ID", "Nombre", asignatura.CarreraId);
            ViewBag.ProfesorId = new SelectList(db.Profesores, "ID", "Cedula", asignatura.ProfesorId);
            return View(asignatura);
        }

        // POST: Asignaturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,CarreraId,ProfesorId,Nombre")] Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignatura).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CarreraId = new SelectList(db.Carreras, "ID", "Nombre", asignatura.CarreraId);
            ViewBag.ProfesorId = new SelectList(db.Profesores, "ID", "Cedula", asignatura.ProfesorId);
            return View(asignatura);
        }

        // GET: Asignaturas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignatura asignatura = await db.Asignaturas.FindAsync(id);
            if (asignatura == null)
            {
                return HttpNotFound();
            }
            return View(asignatura);
        }

        // POST: Asignaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Asignatura asignatura = await db.Asignaturas.FindAsync(id);
            db.Asignaturas.Remove(asignatura);
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
