using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pearson.PSCWinAutomation.Framework
{
    public class Control
    {        
        private Dictionary<string, string> searchProperties = new Dictionary<string,string>();
        private string controlName;
        private string viewName;
        private string parentControl;        
        private string controlType;
        private string controlText;
        private string controlZone;

        public Control(Dictionary<string, string> searchProperties, string controlName, string viewName, string parentControl, string controlZone, string controlType, string controlText)
        {
            this.searchProperties = searchProperties;
            this.controlName = controlName;
            this.viewName = viewName;
            this.parentControl = parentControl;            
            this.controlZone = controlZone;
            this.controlType = controlType;
            this.controlText = controlText;
        }

        public Control(XElement controlXElement, string viewName)
        {
            XElement searchPropertiesXElement = controlXElement.Element("SearchProperties");
            foreach(XElement property in searchPropertiesXElement.Elements())
            {
                this.searchProperties.Add(property.Name.ToString(), property.Value);                
            }
            this.controlZone = controlXElement.Element("ControlZone").Value;
            this.controlName = controlXElement.Attribute("ControlName").ToString();
            this.viewName = viewName;
            this.parentControl = controlXElement.Element("ParentControl").Value;            
            this.controlType = controlXElement.Element("ControlType").Value;
            this.controlText = controlXElement.Element("ControlText").Value;
        }
        public Control(XElement controlXElement, string viewName, string dynamicVariable)
        {
            XElement searchPropertiesXElement = controlXElement.Element("SearchProperties");
            foreach (XElement property in searchPropertiesXElement.Elements())
            {
                this.searchProperties.Add(property.Name.ToString(), property.Value.Replace("()", dynamicVariable));
            }
            this.controlZone = controlXElement.Element("ControlZone").Value;
            this.controlName = controlXElement.Attribute("ControlName").ToString();
            this.viewName = viewName;
            this.parentControl = controlXElement.Element("ParentControl").Value.Replace("()", dynamicVariable);            
            this.controlType = controlXElement.Element("ControlType").Value;
            this.controlText = controlXElement.Element("ControlText").Value.Replace("()", dynamicVariable);
        }
        public Control()
        {
            // TODO: Complete member initialization
        }
        public Dictionary<string, string> SearchProperties
        {
            get
            {
                return searchProperties;
            }
        }       
       
        public string ControlName
        {
            get
            {
                return controlName;
            }
        }
        public string ViewName
        {
            get
            {
                return viewName;
            }
        }
        public string ParentControl
        {
            get
            {
                return parentControl;
            }
        }
        public string ControlType
        {
            get
            {
                return controlType;
            }
        }
        public string ControlZone
        {
            get
            {
                return controlZone;
            }
        }
        public string ControlText
        {
            get
            {
                return controlText;
            }
            set
            {
                controlText = value;
            }
        }         

    }
}
