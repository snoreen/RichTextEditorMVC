using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevxControlsSamples.Models
{
    public class ReportTemplate
    {
        public List<UIControl> Controls { get; set; }
        public string HtmlTemplate { get; set; }
        public string TemplateName { get; set; }
    }
}