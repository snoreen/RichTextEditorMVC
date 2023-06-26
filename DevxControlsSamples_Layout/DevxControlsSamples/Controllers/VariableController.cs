using DevExpress.Web.Mvc;
using DevxControlsSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevxControlsSamples.Helper;
using System.Xml;

namespace DevxControlsSamples.Controllers
{
    public class VariableController : Controller
    {
        private static Variable _variable;
        XMLHandler objXMLHandler;
      
        public VariableController()
        {
            if (_variable == null)
            {
                _variable = new Variable();
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
            ViewBag.DataTypes = new DataTypes().VariableDataTypes;
            List<CustomObject> jsonData = new List<CustomObject>();
            jsonData = new JSONHelper().ReadJsonFile(@"E:\Learning\DotNet\DevxControlsSamples_Layout\DevxControlsSamples\App_Data\CustomerData.json");
            ViewBag.JsonData = jsonData;
            objXMLHandler.DeleteAllHelpNavNodes();
            foreach (var item in VariableDetails.StoredVariables)
            {
                objXMLHandler.AddHelpNavNodeToXml(item);
            }
            @ViewBag.RefreshTreeView = true;
            return View(_variable);
        }

        [HttpPost]
        public ActionResult SaveData(Variable model)
        {
            XMLHandler objXMLHandler = new XMLHandler();
            _variable = model;
            objXMLHandler.DeleteAllHelpNavNodes();
            VariableDetails.StoredVariables.Add(_variable);
            foreach (var item in VariableDetails.StoredVariables)
            {
                objXMLHandler.AddHelpNavNodeToXml(item);
            }
            ViewBag.RefreshTreeView = true;
            _variable = new Variable();
            return RedirectToAction("Index");
        }

        DevxControlsSamples.Models.ProductsEntities db = new DevxControlsSamples.Models.ProductsEntities();

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = VariableDetails.StoredVariables;
            return PartialView("~/Views/Variable/_GridViewPartial.cshtml", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Variable item)
        {
            VariableDetails.StoredVariables.Add(item);            
            return PartialView("~/Views/Variable/_GridViewPartial.cshtml", VariableDetails.StoredVariables);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Variable item)
        {

            // Find the item in the list based on the ControlId
            Variable controlToUpdate = VariableDetails.StoredVariables.Find(c => c.VariableId == item.VariableId);

            if (controlToUpdate != null)
            {
                // Update the values of the found item
                controlToUpdate = item;

                // If there are other properties you want to update, assign the new values here

                // Replace the updated item in the list
                int index = VariableDetails.StoredVariables.IndexOf(controlToUpdate);
                VariableDetails.StoredVariables[index] = controlToUpdate;
            }
            return PartialView("~/Views/Variable/_GridViewPartial.cshtml", VariableDetails.StoredVariables);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.Int32 VariableId)
        {
            int indexToDelete = VariableDetails.StoredVariables.FindIndex(c => c.VariableId == VariableId);

            if (indexToDelete >= 0)
            {
                // Remove the item from the list
                VariableDetails.StoredVariables.RemoveAt(indexToDelete);
                objXMLHandler.DeleteAllHelpNavNodes();
                foreach (var item in VariableDetails.StoredVariables)
                {
                    objXMLHandler.AddHelpNavNodeToXml(item);
                }
                ViewBag.RefreshTreeView = true;
            }

            return PartialView("~/Views/Variable/_GridViewPartial.cshtml", VariableDetails.StoredVariables);
        }
    }
}