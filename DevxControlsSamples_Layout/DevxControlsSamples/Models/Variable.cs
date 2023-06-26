using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevxControlsSamples.Models
{
    public class Variable
    {
        public int VariableId { get; set; }
        public string VariableName { get; set; }
        public string DataType { get; set; }
        [AllowHtml]
        public string Value { get; set; }
        public string DefaultValue { get; set; }
        public bool AllowNull { get; set; }
        public bool Bound { get; set; }
        public string PathToSource { get; set; }
    }

    public class DataTypes
    {
        public DataTypes()
        {
            VariableDataTypes = new List<string>();            
            VariableDataTypes.Add("string"); 
            VariableDataTypes.Add("int");
            VariableDataTypes.Add("datetime");
            VariableDataTypes.Add("double");
            VariableDataTypes.Add("bool");           
        }
        
        public List<string> VariableDataTypes { get; set; }
    }    
}