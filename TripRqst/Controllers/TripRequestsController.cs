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
using TripRqst.Utils;

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
        public ActionResult Create(string view = "Create")
        {
            var m = new TripRequest();
            ViewBag.Alocacoes = db.TR_Alocacoes.Where(a => a.Active);
            ViewBag.Justificacoes = db.TR_Justificacoes.Where(j => j.Active);
            ViewBag.Motivos = db.TR_Motivos.Where(mm => mm.Active);
            ViewBag.Username = User.Identity.Name;

            /*
            var groupDomestic = new SelectListGroup { Name = "Domestic" };
            var groupIntercontinental = new SelectListGroup { Name = "Intercontinental" };
            ViewBag.Countries = (IEnumerable<SelectListItem>) db.Countries
                .Where(c=>c.Active)
                .ToList()
                .Select(c => new SelectListItem
                {
                    Value =c.Code,
                    Text =c.Name,
                    Selected = c.Name.Equals("Other"),
                    Group = c.IsDomestic ? groupDomestic : groupIntercontinental
                }).OrderBy(c=>c.Group.Name).ThenBy(c=>c.Text);
                */
            return View(view, m);
        }

        // POST: TripRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TripRequest model, HttpPostedFileBase justEmail)
        {
            if (ModelState.IsValid)
            {
                db.TR_requests.Add(model);
                await db.SaveChangesAsync();

                if (justEmail != null && justEmail.ContentLength > 0)
                {
                    var fileName = System.IO.Path.GetFileName(justEmail.FileName);
                    var path = Server.MapPath("~/App_Data/uploads/TripRequests/")+model.Id;
                    System.IO.Directory.CreateDirectory(path);
                    var filepath = System.IO.Path.Combine(path, fileName);
                    justEmail.SaveAs(filepath);

                    model.EmailAnexo = filepath;
                    await db.SaveChangesAsync();
                }

                return RedirectToAction("Index");
            }

            ViewBag.Alocacoes = db.TR_Alocacoes.Where(a => a.Active);
            ViewBag.Justificacoes = db.TR_Justificacoes.Where(j => j.Active);
            ViewBag.Motivos = db.TR_Motivos.Where(mm => mm.Active);

            return View(model);
        }

        protected ActionResult Pdf(string fileDownloadName, string viewName, object model)
        {
            // Based on View() code in Controller base class from MVC
            if (model != null)
            {
                ViewData.Model = model;
            }
            PdfResult pdf = new PdfResult()
            {
                FileDownloadName = fileDownloadName,
                ViewName = viewName,
                ViewData = ViewData,
                TempData = TempData,
                ViewEngineCollection = ViewEngineCollection
            };
            return pdf;
        }
        public async Task<ActionResult> PDFTest()
        {
            return Pdf(null, null, new int[] { 1, 2, 3 });
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,DataDoPedido,Passageiro,MotivoCode,MotivoName,Identificacao,Origem,Destino,Partida,Chegada,DiasDeAntecedencia,JustificacaoCode,JustificacaoName,EmailAnexo,CustoAviao,CustoHotel,CustoCarro,CustoOutros,CustoTotal,AlocacaoCode,AlocacaoName")] TripRequest tripRequest)
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
