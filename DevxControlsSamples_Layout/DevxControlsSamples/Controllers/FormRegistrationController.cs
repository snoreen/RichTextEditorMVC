using DevExpress.Web.Mvc;
using DevxControlsSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevxControlsSamples.Controllers
{
    public class FormRegistrationController : Controller
    {
        public ActionResult RegistrationForm()
        {
            return View("RegistrationForm", new RegistrationForm());
        }

        [HttpPost]       
        public ActionResult SaveDataToList(FormCollection form)
        {
            string firstName = form["RegistrationData.FirstName"];
            string lastName = form["RegistrationData.LastName"];
            string gender = form["RegistrationData.Gender"];
            string country = form["RegistrationData.Country"];
            string email = form["AuthorizationData.Email"];
            string password = form["AuthorizationData.Password"];
            string confirmPassword = form["AuthorizationData.ConfirmPassword"];

            // Process the form data as needed

            return RedirectToAction("RegistrationForm");
        }
        [HttpPost]
        public ActionResult RegistrationForm(RegistrationForm registrationForm)
        {
            if (ModelState.IsValid && CaptchaExtension.GetIsValid("captcha"))
            {
                ViewBag.SuccessValidation = true;
                registrationForm = new RegistrationForm();
            }
            return View("RegistrationForm", registrationForm);
        }
        public ActionResult RegistrationFormCaptchaPartialView()
        {
            
            return PartialView();
        }
    }
}