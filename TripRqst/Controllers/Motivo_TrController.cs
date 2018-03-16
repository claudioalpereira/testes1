using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TripRqst.Models;

namespace TripRqst.Controllers
{
    public class Motivo_TrController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Motivo_Tr
        public async Task<ActionResult> Index()
        {
            return View(await db.TR_Motivos.ToListAsync());
        }

        // GET: Motivo_Tr/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motivo_Tr motivo_Tr = await db.TR_Motivos.FindAsync(id);
            if (motivo_Tr == null)
            {
                return HttpNotFound();
            }
            return View(motivo_Tr);
        }

        // GET: Motivo_Tr/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Motivo_Tr/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Name,Info")] Motivo_Tr motivo_Tr)
        {
            if (ModelState.IsValid)
            {
                db.TR_Motivos.Add(motivo_Tr);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(motivo_Tr);
        }

        // GET: Motivo_Tr/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motivo_Tr motivo_Tr = await db.TR_Motivos.FindAsync(id);
            if (motivo_Tr == null)
            {
                return HttpNotFound();
            }
            return View(motivo_Tr);
        }

        // POST: Motivo_Tr/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Name,Info")] Motivo_Tr motivo_Tr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motivo_Tr).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(motivo_Tr);
        }

        // GET: Motivo_Tr/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motivo_Tr motivo_Tr = await db.TR_Motivos.FindAsync(id);
            if (motivo_Tr == null)
            {
                return HttpNotFound();
            }
            return View(motivo_Tr);
        }

        // POST: Motivo_Tr/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Motivo_Tr motivo_Tr = await db.TR_Motivos.FindAsync(id);
            db.TR_Motivos.Remove(motivo_Tr);
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
