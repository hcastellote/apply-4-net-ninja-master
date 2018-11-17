using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ninja.model.Manager;
using ninja.model.Entity;
using ninja.model.Mock;
namespace ninja.Controllers
{
    public class InvoiceController : Controller
    {
        public ActionResult List()
        {

            return View(new InvoiceManager().GetAll());

        }

        public ActionResult Detail(long id = 0)
        {

            return View(new InvoiceManager().GetById(id));

        }

        [HttpGet]
        public ActionResult New()
        {
            ViewBag.Message = "This is the new view.";
            var factura = new Invoice();

            return View(factura);
        }

        [HttpPost]
        public ActionResult New(Invoice unaFactura)
        {
            ViewBag.Message = "This is the new view.";
            var unManager = new InvoiceManager();

            long id = unManager.GetAll().Last().Id + 1;
            unaFactura.Id = id;
            unManager.Insert(unaFactura);

            return RedirectToAction("New");
        }

        [HttpGet]
        public ActionResult Update(long id)
        {
            ViewBag.Message = "This is the update view.";
            

            return View(new InvoiceManager().GetById(id));
        }

        [HttpPost]
        public ActionResult Update(Invoice unInvoice)
        {
            ViewBag.Message = "This is the update view.";
            var unManager = new InvoiceManager();
            unManager.Delete(unInvoice.Id);
            unManager.Insert(unInvoice);

            return View();
        }
        //[HttpGet]
        public ActionResult Delete(long id = 0)
        {
            InvoiceManager invoiceManager = new InvoiceManager(); ;
            if (id != 0)
            {
                invoiceManager.Delete(id);
                
            }
            //IList<Invoice> invoices;
            //invoices = new InvoiceManager().GetAll();

            ViewBag.Message = "This is the delete view.";
        

            return View(invoiceManager.GetMock());
        }

    }
}