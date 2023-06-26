using DevExpress.Web.Mvc;
using DevxControlsSamples.Helper;
using DevxControlsSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace DevxControlsSamples.Controllers
{
    public class UIControlController : Controller
    {
        // GET: Control
        private static UIControl _control;
        XMLHandler objXMLHandler;
        
        public UIControlController()
        {
            if (_control == null)
            {
                _control = new UIControl();
            }
            objXMLHandler = new XMLHandler();
        }
        public ActionResult GetXmlData()
        {
            // Code to read and return the updated XML data
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Server.MapPath("~/App_Data/tvData.xml")); // Replace with the path to your XML file
            return Content(xmlDoc.OuterXml, "application/xml");
        }

        public ActionResult Index()
        {
            ViewBag.DisplayTypes = new DisplayProperty().DisplayTypes;
            ViewBag.ControlTyes = new ControlType().ControlTypes;
            ViewBag.ControlValues = VariableDetails.StoredVariables;
            @ViewBag.RefreshTreeView = false;
            
            objXMLHandler.DeleteAllControlHelpNavNodes();
            foreach (var item in ControlDetails.StoredControls)
            {
                objXMLHandler.AddControlsToHelpNavNodeToXml(item);
            }
            @ViewBag.RefreshTreeView = false;
            return View(_control);
        }
        [HttpPost]
        public ActionResult SaveData(UIControl model)
        {
            
            _control = model;
            objXMLHandler.DeleteAllControlHelpNavNodes();
            ControlDetails.StoredControls.Add(_control);
            foreach (var item in ControlDetails.StoredControls)
            {
                objXMLHandler.AddControlsToHelpNavNodeToXml(item);
            }
            ViewBag.RefreshTreeView = true;
            _control = new UIControl();
            return RedirectToAction("Index");
        }
        [ValidateInput(false)]
        public ActionResult GridView1Partial()
        {
            var model = ControlDetails.StoredControls;
            return PartialView("~/Views/UIControl/_GridView1Partial.cshtml", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] UIControl item)
        {
            XMLHandler objXMLHandler = new XMLHandler();
            _control = item;
            objXMLHandler.DeleteAllControlHelpNavNodes();
            ControlDetails.StoredControls.Add(_control);
            foreach (var control in ControlDetails.StoredControls)
            {
                objXMLHandler.AddControlsToHelpNavNodeToXml(control);
            }
            ViewBag.RefreshTreeView = true;
            return RedirectToAction("Index");
            
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] UIControl item)
        {
            // Find the item in the list based on the ControlId
            UIControl controlToUpdate = ControlDetails.StoredControls.Find(c => c.ControlId == item.ControlId);

            if (controlToUpdate != null)
            {
                // Update the values of the found item
                controlToUpdate = item;

                // If there are other properties you want to update, assign the new values here

                // Replace the updated item in the list
                int index = ControlDetails.StoredControls.IndexOf(controlToUpdate);
                ControlDetails.StoredControls[index] = controlToUpdate;
            }
            return PartialView("~/Views/UIControl/_GridView1Partial.cshtml", ControlDetails.StoredControls);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialDelete(string ControlId)
        {
            int indexToDelete = ControlDetails.StoredControls.FindIndex(c => c.ControlId == ControlId);

            if (indexToDelete >= 0)
            {
                // Remove the item from the list
                ControlDetails.StoredControls.RemoveAt(indexToDelete);
            }
            return PartialView("~/Views/UIControl/_GridView1Partial.cshtml", ControlDetails.StoredControls);
        }
    }
}