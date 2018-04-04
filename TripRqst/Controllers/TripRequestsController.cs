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
using Microsoft.AspNet.Identity;
using TuesPechkin;
using System.Drawing.Printing;

namespace TripRqst.Controllers
{
    [Authorize]
    public class TripRequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TripRequests
        // GET: TripRequests/5
        [Authorize(Roles = "manager, admin, assistent")]
        public async Task<ActionResult> Index()
        {
            if (User.IsInRole("admin") || User.IsInRole("manager") || User.IsInRole("assistent"))
                return await All();
            else
                return await My();
        }

        // GET: TripRequests/All
        [Authorize(Roles = "manager, admin, assistent")]
        public async Task<ActionResult> All()
        {
            return View(await db.TR_Requests.ToListAsync());
        }

        // GET: TripRequests/My
        public async Task<ActionResult> My()
        {
            var me = User.Identity.GetUserName();
            return View(await db.TR_Requests.Where(r=>r.Passageiro.Equals(me)).ToListAsync());
        }

        // GET: TripRequests/5
        // GET: TripRequests/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripRequest tripRequest = await db.TR_Requests.FindAsync(id);
            if (tripRequest == null)
            {
                return HttpNotFound();
            }
            return View("Details", tripRequest);
        }

        // GET: TripRequests/New
        public ActionResult New(string view = "New")
        {
            var m = new TripRequest();
            ViewBag.Alocacoes = db.TR_Alocacoes.Where(a => a.Active);
            ViewBag.Justificacoes = db.TR_Justificacoes.Where(j => j.Active);
            ViewBag.Motivos = db.TR_Motivos.Where(mm => mm.Active);
            ViewBag.Username = User.Identity.Name;
            
            return View(view, m);
        }

        // POST: TripRequests/New
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> New(TripRequest model, HttpPostedFileBase justEmail)
        {
            if (ModelState.IsValid)
            {
                db.TR_Requests.Add(model);
                await db.SaveChangesAsync();

                model.Pdf = CreatePDF(model);

                if (justEmail != null && justEmail.ContentLength > 0)
                {
                    var fileName = System.IO.Path.GetFileName(justEmail.FileName);
                    var path = GetUploadsPath(model.Id);
                    System.IO.Directory.CreateDirectory(path);
                    var filepath = System.IO.Path.Combine(path, fileName);
                    justEmail.SaveAs(filepath);

                    model.EmailAnexo = System.IO.Path.Combine(""+model.Id, fileName);
                   
                }
                await db.SaveChangesAsync();

                return RedirectToAction("Details", new { id = model.Id });
            }

            ViewBag.Alocacoes = db.TR_Alocacoes.Where(a => a.Active);
            ViewBag.Justificacoes = db.TR_Justificacoes.Where(j => j.Active);
            ViewBag.Motivos = db.TR_Motivos.Where(mm => mm.Active);

            return View(model);
        }

        // http://www.dotnetcurry.com/aspnet-mvc/1369/print-aspnet-mvc-view-to-pdf
        // https://github.com/tuespetre/TuesPechkin
        // https://github.com/dotnetcurry/mvc-print-pdf
        // https://forums.asp.net/t/2017674.aspx?How+to+return+rendered+razor+view+from+Web+API+controller
        // https://daveaglick.com/posts/using-aspnet-mvc-and-razor-to-generate-pdf-files
        private string CreatePDF(TripRequest tr)
        {
            string html;
            string id = ""+tr.Id;
            using (var writer = new System.IO.StringWriter())
            {
                var razorViewEngine = new RazorViewEngine();
                var razorViewResult = razorViewEngine.FindView(ControllerContext, "Details", "", false);
                var viewContext = new ViewContext(ControllerContext, razorViewResult.View, new ViewDataDictionary(tr), new TempDataDictionary(), writer);
                razorViewResult.View.Render(viewContext, writer);
                html = writer.ToString();
            }
            var document = new HtmlToPdfDocument
            {
                GlobalSettings =
                {
                    ProduceOutline = true,
                    DocumentTitle = "Trip request #"+id,
                    PaperSize = PaperKind.A4, // Implicit conversion to PechkinPaperSize
                    Margins =
                    {
                        All = 1.375,
                        Unit = Unit.Centimeters
                    }
                },
                Objects =
                {
//                    new ObjectSettings { PageUrl = "http://localhost:29900/TripRequests/"+tr.Id },
                    new ObjectSettings { HtmlText= html }
                }
            };
            
            IConverter converter =
            new StandardConverter(
                new PdfToolset(
                    new Win32EmbeddedDeployment(
                        new TempFolderDeployment())));

            byte[] result = converter.Convert(document);

            // save
            var fileName = "triprequest_"+id+".pdf";
            var path = GetUploadsPath(id);
            System.IO.Directory.CreateDirectory(path);
            var filepath = System.IO.Path.Combine(path, fileName);
           

            System.IO.File.WriteAllBytes(filepath, result);

            return System.IO.Path.Combine(id, fileName);

        }

        public FileResult File(string filepath)
        {
            // https://stackoverflow.com/a/3605510/9230822
            byte[] fileBytes = System.IO.File.ReadAllBytes(GetUploadsPath(filepath));
            string fileName = System.IO.Path.GetFileName(filepath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, filepath);
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
            TripRequest tripRequest = await db.TR_Requests.FindAsync(id);
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
            TripRequest tripRequest = await db.TR_Requests.FindAsync(id);
            db.TR_Requests.Remove(tripRequest);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private string GetUploadsPath(string sufix = "")
        {
            return System.IO.Path.Combine(Server.MapPath("~/App_Data/uploads/TripRequests/"), sufix);
        }
        private string GetUploadsPath(int i)
        {
            return GetUploadsPath(""+i);
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
