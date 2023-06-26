using DevExpress.Web.Mvc;
using DevxControlsSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevxControlsSamples.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult DataBindingToXML()
        {
            return View("Index");
        }
        public ActionResult ClientSideEventsDemoView(string[] events)
        {
            return ClientSideEventsDemoView(events, null);
        }
        public ActionResult ClientSideEventsDemoView(string[] events, object model)
        {
            return ClientSideEventsDemoView(events, true, model);
        }
        public ActionResult ClientSideEventsDemoView(string[] events, bool showEventListPanel, object model)
        {
            ViewData["ClientSideEvents"] = events;
            ViewData["ShowEventListPanel"] = showEventListPanel;
            return View("ClientSideEvents", model);
        }
        public ActionResult ClientSideEvents()
        {
            return ClientSideEventsDemoView(new string[]{
                "Init",
                "ExpandedChanging",
                "ExpandedChanged",
                "CheckedChanged",
                "NodeClick"
            });
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        DevxControlsSamples.Models.ProductsEntities db = new DevxControlsSamples.Models.ProductsEntities();

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = db.ProductDetails;
            return PartialView("~/Views/Home/_GridViewPartial.cshtml", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] DevxControlsSamples.Models.Product item)
        {
            var model = db.Products;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("~/Views/Home/_GridViewPartial.cshtml", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] DevxControlsSamples.Models.Product item)
        {
            var model = db.Products;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.ProductId == item.ProductId);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("~/Views/Home/_GridViewPartial.cshtml", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.Int32 ProductId)
        {
            var model = db.Products;
            if (ProductId >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.ProductId == ProductId);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("~/Views/Home/_GridViewPartial.cshtml", model.ToList());
        }



        DevxControlsSamples.Models.ProductsEntities db1 = new DevxControlsSamples.Models.ProductsEntities();

        public ActionResult ChartPartial()
        {
            var model = db1.ProductSales;
            return PartialView("~/Views/Home/_ChartPartial.cshtml", model.ToList());
        }

        DevxControlsSamples.Models.ProductsEntities db2 = new DevxControlsSamples.Models.ProductsEntities();

        [ValidateInput(false)]
        public ActionResult DataViewPartial()
        {
            var model = db2.ProductDetails;
            return PartialView("~/Views/UserForm/_DataViewPartial.cshtml", model.ToList());
        }
        
        public ActionResult PieViewPartial()
        {
            ChartPieDoughnutDemoOptions options = new ChartPieDoughnutDemoOptions();
            var model = db2.ProductSales.Take(7).ToList(); ;
            options.Data = model;
            return PartialView("~/Views/Home/_PieViewPartial.cshtml", options);
        }

        
    }
}