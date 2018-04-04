using MvcRazorToPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TripRqst.Models;

namespace TripRqst.Controllers
{
    public class PdfController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var model = new PdfExample
            {
                Heading = "Heading",
                Items = new List<BasketItem>
                {
                    new BasketItem
                    {
                        Id = 1,
                        Description = "Item 1",
                        Price = 1.99m
                    },
                    new BasketItem
                    {
                        Id = 2,
                        Description = "Item 2",
                        Price = 2.99m
                    }
                }
            };


            var xxx = db.TR_Requests.FirstOrDefault();
            return new PdfActionResult(xxx);
        }

        
       

        
    }
}