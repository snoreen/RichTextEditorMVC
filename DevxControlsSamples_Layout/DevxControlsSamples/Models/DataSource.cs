using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevxControlsSamples.Models
{
    public static class DataSource
    {
    }
    public class VariableDetails
    {
        public static List<Variable> StoredVariables { get; set; }

        static VariableDetails()
        {
            StoredVariables = new List<Variable>();
            StoredVariables.Add(new Variable()
            {
                VariableId = 1,
                VariableName = "FirstName",
                DataType = "string",
                Value = "Sumaira",
                DefaultValue = "FirstName",
                AllowNull = false
            }); ;
            StoredVariables.Add(new Variable()
            {
                VariableId = 2,
                VariableName = "LastName",
                DataType = "string",
                Value = "Sohail",
                DefaultValue = "LastName",
                AllowNull = true
            });
            StoredVariables.Add(new Variable()
            {
                VariableId = 3,
                VariableName = "Email",
                DataType = "string",
                Value = "ssohail@gmail.com",
                DefaultValue = "Email",
                AllowNull = false
            });
        }



    }
    public class ControlDetails
    {
        public static List<UIControl> StoredControls { get; set; }

        static ControlDetails()
        {
            StoredControls = new List<UIControl>();
            StoredControls.Add(new UIControl()
            {
                ControlId = "FirstName",
                ControlName = "FirstName",
                Type = "Text",
                Value = "Sumaira",
                Label = "First Name",
                CustomClass = "",
                Display = "editable",
                Mandatory = true
               
            });
            StoredControls.Add(new UIControl()
            {
                ControlId = "LastName",
                ControlName = "LastName",
                Type = "Text",
                Value = "Sohail",
                Label = "Last Name",
                CustomClass = "custom-control",
                Display = "editable",
                Mandatory = true

            });

        }


    }
}