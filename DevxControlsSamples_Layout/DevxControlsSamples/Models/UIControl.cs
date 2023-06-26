using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevxControlsSamples.Models
{
    public class UIControl
    {
        public string ControlId { get; set; }
        public string ControlName { get; set; }
        public string Type { get; set; }
        [AllowHtml]
        public string Value { get; set; }
        public string Label { get; set; }
        public string Display { get; set; }
        public string CustomClass { get; set; }
        public bool Mandatory { get; set; }
        
    }

    public class DisplayProperty
    {
        public List<string> DisplayTypes = new List<string>();
        public DisplayProperty()
        {
            DisplayTypes = new List<string>();
            DisplayTypes.Add("Editable");
            DisplayTypes.Add("Readonly");
            DisplayTypes.Add("Hidden");            
        }
       
    }

    public class ControlType
    {
        public List<string> ControlTypes = new List<string>();
        public ControlType()
        {
            ControlTypes = new List<string>();
            ControlTypes.Add("Text");
            ControlTypes.Add("Button");
            ControlTypes.Add("RichText");
            ControlTypes.Add("Label");
            ControlTypes.Add("Image");
            ControlTypes.Add("HTML");
        }
       
    }

}