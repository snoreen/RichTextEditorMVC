
using DevxControlsSamples.Models;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevxControlsSamples.Controllers
{
    public class ReportTemplateController : Controller
    {
        public ActionResult Index()
        {
            List<UIControl> controls = GetControls(); // Get the list of controls from your data source

            var model = new ReportTemplate
            {
                Controls = ControlDetails.StoredControls,
                HtmlTemplate = string.Empty
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult GeneratePdf(ReportTemplate model)
        {           
            // Create a new PdfDocument object
            PdfDocument document = new PdfDocument();
            // Create a PdfPage
            PdfPage page = document.AddPage();
            // Create an HtmlToPdf converter
            HtmlToPdf converter = new HtmlToPdf();
            // Convert the HTML template to PDF and save it to the PdfPage
            PdfDocument doc = converter.ConvertHtmlString(model.HtmlTemplate);
            doc.Save(@"E:\Learning\DotNet\Reports\PDF\" + model.TemplateName+ ".pdf");

            return RedirectToAction("Index");
        }
       
        private List<UIControl> GetControls()
        {
            List<UIControl> _controls = ControlDetails.StoredControls;
           
            return ControlDetails.StoredControls; ;
        }
    }
}