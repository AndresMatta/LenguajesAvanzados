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
    public class UniversidadesController : Controller
    {
        private LAContext db = new LAContext();

        // GET: Universidades
        public async Task<ActionResult> Index()
        {
            return View(await db.Universidades.ToListAsync());
        }

        // GET: Universidades/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universidad universidad = await db.Universidades.FindAsync(id);
            if (universidad == null)
            {
                return HttpNotFound();
            }
            return View(universidad);
        }

        // GET: Universidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Universidades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Nombre")] Universidad universidad)
        {
            if (ModelState.IsValid)
            {
                db.Universidades.Add(universidad);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(universidad);
        }

        // GET: Universidades/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universidad universidad = await db.Universidades.FindAsync(id);
            if (universidad == null)
            {
                return HttpNotFound();
            }
            return View(universidad);
        }

        // POST: Universidades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Nombre")] Universidad universidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(universidad).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(universidad);
        }

        // GET: Universidades/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universidad universidad = await db.Universidades.FindAsync(id);
            if (universidad == null)
            {
                return HttpNotFound();
            }
            return View(universidad);
        }

        // POST: Universidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Universidad universidad = await db.Universidades.FindAsync(id);
            db.Universidades.Remove(universidad);
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
