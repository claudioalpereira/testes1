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
    public class TripRequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TripRequests
        public async Task<ActionResult> Index()
        {
            return View(await db.TR_requests.ToListAsync());
        }

        // GET: TripRequests/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripRequest tripRequest = await db.TR_requests.FindAsync(id);
            if (tripRequest == null)
            {
                return HttpNotFound();
            }
            return View(tripRequest);
        }

        // GET: TripRequests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TripRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DataDoPedido,Passageiro,Identificacao,Origem,Destino,Partida,Chegada,DiasDeAntecedencia,CustoAviao,CustoHotel,CustoCarro,CustoOutros,CustoTotal")] TripRequest tripRequest)
        {
            if (ModelState.IsValid)
            {
                db.TR_requests.Add(tripRequest);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tripRequest);
        }

        // GET: TripRequests/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripRequest tripRequest = await db.TR_requests.FindAsync(id);
            if (tripRequest == null)
            {
                return HttpNotFound();
            }
            return View(tripRequest);
        }

        // POST: TripRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DataDoPedido,Passageiro,Identificacao,Origem,Destino,Partida,Chegada,DiasDeAntecedencia,CustoAviao,CustoHotel,CustoCarro,CustoOutros,CustoTotal")] TripRequest tripRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tripRequest).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tripRequest);
        }

        // GET: TripRequests/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripRequest tripRequest = await db.TR_requests.FindAsync(id);
            if (tripRequest == null)
            {
                return HttpNotFound();
            }
            return View(tripRequest);
        }

        // POST: TripRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TripRequest tripRequest = await db.TR_requests.FindAsync(id);
            db.TR_requests.Remove(tripRequest);
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
