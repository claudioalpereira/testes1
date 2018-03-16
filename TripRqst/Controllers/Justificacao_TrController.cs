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
    public class Justificacao_TrController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Justificacao_Tr
        public async Task<ActionResult> Index()
        {
            return View(await db.TR_Justificacoes.ToListAsync());
        }

        // GET: Justificacao_Tr/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Justificacao_Tr justificacao_Tr = await db.TR_Justificacoes.FindAsync(id);
            if (justificacao_Tr == null)
            {
                return HttpNotFound();
            }
            return View(justificacao_Tr);
        }

        // GET: Justificacao_Tr/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Justificacao_Tr/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Name,Info,RequiresEmail,RequiresEmailFromAuthorizedSender")] Justificacao_Tr justificacao_Tr)
        {
            if (ModelState.IsValid)
            {
                db.TR_Justificacoes.Add(justificacao_Tr);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(justificacao_Tr);
        }

        // GET: Justificacao_Tr/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Justificacao_Tr justificacao_Tr = await db.TR_Justificacoes.FindAsync(id);
            if (justificacao_Tr == null)
            {
                return HttpNotFound();
            }
            return View(justificacao_Tr);
        }

        // POST: Justificacao_Tr/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Name,Info,RequiresEmail,RequiresEmailFromAuthorizedSender")] Justificacao_Tr justificacao_Tr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(justificacao_Tr).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(justificacao_Tr);
        }

        // GET: Justificacao_Tr/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Justificacao_Tr justificacao_Tr = await db.TR_Justificacoes.FindAsync(id);
            if (justificacao_Tr == null)
            {
                return HttpNotFound();
            }
            return View(justificacao_Tr);
        }

        // POST: Justificacao_Tr/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Justificacao_Tr justificacao_Tr = await db.TR_Justificacoes.FindAsync(id);
            db.TR_Justificacoes.Remove(justificacao_Tr);
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
