using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace DevxControlsSamples.Helper
{
	public class JSONHelper
	{
        public List<CustomObject> ReadJsonFile(string filePath)
        {
            try
            {
                string jsonData = File.ReadAllText(filePath);

                JToken token = JToken.Parse(jsonData);
                if (token is JObject)
                {
                    JObject jsonObject = (JObject)token;

                    List<CustomObject> customObjects = new List<CustomObject>();

                    TraverseJsonObject(jsonObject, customObjects, "");

                    return customObjects;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine("Error reading JSON file: " + ex.Message);
            }

            return null;
        }

        private void TraverseJsonObject(JObject jsonObject, List<CustomObject> customObjects, string parentPropertyName)
        {
            foreach (JProperty property in jsonObject.Properties())
            {
                CustomObject customObject = new CustomObject
                {
                    PropertyName = !string.IsNullOrEmpty(parentPropertyName) ? parentPropertyName + "." + property.Name : property.Name,
                    PropertyValue = property.Value.ToString()
                };

                customObjects.Add(customObject);

                if (property.Value.Type == JTokenType.Object)
                {
                    TraverseJsonObject((JObject)property.Value, customObjects, !string.IsNullOrEmpty(parentPropertyName) ? parentPropertyName + "." + property.Name : property.Name);
                }
            }
        }
    }

    public class CustomObject
    {
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
    }

    
}