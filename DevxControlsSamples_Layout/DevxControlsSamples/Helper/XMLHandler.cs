using DevxControlsSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Web.Mvc;


namespace DevxControlsSamples.Helper
{
    public class XMLHandler
    {
        public void AddHelpNavNodeToXml(Variable item)
        {
            string xmlFilePath = @"E:\Learning\DotNet\DevxControlsSamples_Layout\DevxControlsSamples\App_Data\tvData.xml";// "~/App_Data/tvData.xml"; // Replace with the actual file path

            // Load the XML document
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            // Find the <class> node with the specified attributes
            XmlNode classNode = xmlDoc.SelectSingleNode("//class[@HelpUrl='https://localhost:44392/Variable/Index' and @Title='Variables' and @NodeTypeImage='~/Content/TreeView/HelpNav/class.gif']");

            if (classNode != null)
            {
                // Create a new <helpNavNode> node
                XmlElement helpNavNode = xmlDoc.CreateElement("helpNavNode");
                helpNavNode.SetAttribute("HelpUrl", "javascript:void(16);");
                helpNavNode.SetAttribute("Title", item.VariableName);

                // Add the <helpNavNode> node to the <class> node
                classNode.AppendChild(helpNavNode);
            }

            // Save the modified XML document
            xmlDoc.Save(xmlFilePath);
        }

        public void AddControlsToHelpNavNodeToXml(UIControl item)
        {
            string xmlFilePath = @"E:\Learning\DotNet\DevxControlsSamples_Layout\DevxControlsSamples\App_Data\tvData.xml";// "~/App_Data/tvData.xml"; // Replace with the actual file path

            // Load the XML document
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            // Find the <class> node with the specified attributes
            XmlNode classNode = xmlDoc.SelectSingleNode("//class[@HelpUrl='https://localhost:44392/UIControl/Index' and @Title='Controls' and @NodeTypeImage='~/Content/TreeView/HelpNav/class.gif']");

            if (classNode != null)
            {
                // Create a new <helpNavNode> node
                XmlElement helpNavNode = xmlDoc.CreateElement("helpNavNode");
                helpNavNode.SetAttribute("HelpUrl", "javascript:void(16);");
                helpNavNode.SetAttribute("Title", item.ControlName);

                // Add the <helpNavNode> node to the <class> node
                classNode.AppendChild(helpNavNode);
            }

            // Save the modified XML document
            xmlDoc.Save(xmlFilePath);
        }

        public void DeleteAllHelpNavNodes()
        {
            string xmlFilePath = @"E:\Learning\DotNet\DevxControlsSamples_Layout\DevxControlsSamples\App_Data\tvData.xml";// "~/App_Data/tvData.xml"; // Replace with the actual file path

            // Load the XML document
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            // Find the <class> node with the specified attributes
            XmlNode classNode = xmlDoc.SelectSingleNode("//class[@HelpUrl='https://localhost:44392/Variable/Index' and @Title='Variables' and @NodeTypeImage='~/Content/TreeView/HelpNav/class.gif']");

            if (classNode != null)
            {
                // Remove all existing <helpNavNode> nodes under the <class> node
                XmlNodeList helpNavNodes = classNode.SelectNodes("helpNavNode");
                foreach (XmlNode node in helpNavNodes)
                {
                    classNode.RemoveChild(node);
                }
            }
            xmlDoc.Save(xmlFilePath);
        }
        public void DeleteAllControlHelpNavNodes()
        {
            string xmlFilePath = @"E:\Learning\DotNet\DevxControlsSamples_Layout\DevxControlsSamples\App_Data\tvData.xml";// "~/App_Data/tvData.xml"; // Replace with the actual file path

            // Load the XML document
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            // Find the <class> node with the specified attributes
            XmlNode classNode = xmlDoc.SelectSingleNode("//class[@HelpUrl='https://localhost:44392/UIControl/Index' and @Title='Controls' and @NodeTypeImage='~/Content/TreeView/HelpNav/class.gif']");

            if (classNode != null)
            {
                // Remove all existing <helpNavNode> nodes under the <class> node
                XmlNodeList helpNavNodes = classNode.SelectNodes("helpNavNode");
                foreach (XmlNode node in helpNavNodes)
                {
                    classNode.RemoveChild(node);
                }
            }
            xmlDoc.Save(xmlFilePath);
        }

    }


}