using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevxControlsSamples.Controllers
{
    public class UserFormController : Controller
    {
        // GET: UserForm
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RichEditPartial()
        {
            return PartialView("~/Views/UserForm/_RichEditPartial.cshtml");
        }

        public ActionResult RichEdit1Partial()
        {
            return PartialView("~/Views/UserForm/_RichEdit1Partial.cshtml");
        }
    }
}