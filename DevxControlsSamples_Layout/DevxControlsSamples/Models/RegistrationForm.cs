using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevxControlsSamples.Models
{
    public class RegistrationForm
    {
        RegistrationData registrationData;
        [Display(Name = "Registration Data")]
        public RegistrationData RegistrationData
        {
            get
            {
                if (registrationData == null)
                    registrationData = new RegistrationData();
                return registrationData;
            }
        }

        AuthorizationData authorizationData;
        [Display(Name = "Authorization Data")]
        public AuthorizationData AuthorizationData
        {
            get
            {
                if (authorizationData == null)
                    authorizationData = new AuthorizationData();
                return authorizationData;
            }
        }
    }
    public enum Gender { Male, Female };
    public class RegistrationData
    {
        [Required(ErrorMessage = "*")]
        [DisplayFormat(NullDisplayText = "First Name")]
        [Display(Name = "Caption")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "*")]
        [DisplayFormat(NullDisplayText = "Last Name")]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Country { get; set; }

        public static IEnumerable<string> GetPossibleCountries()
        {
            return null;
            //return NorthwindDataProvider.DB.Invoices.Select(i => i.Country).ToList().OfType<string>().Distinct();
        }
    }
    public class AuthorizationData
    {
        [Display(Name = "E-mail")]
        [Required]
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "E-mail is invalid")]
        public string Email { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password you entered do not match")]
        public string ConfirmPassword { get; set; }
    }
}