using System;
using System.Xml.Linq;

namespace XLocalizer.Resx
{
    /// <summary>
    /// Model for exporting DB entities to Resx file
    /// </summary>
    public class ResxElement : IEquatable<ResxElement>
    {
        /// <summary>
        /// Initialize a new instance of ResxElement
        /// </summary>
        public ResxElement()
        {

        }

        /// <summary>
        /// Initializes a new instance of ResxElement from XElement
        /// </summary>
        /// <param name="element"></param>
        public ResxElement(XElement element)
        {
            this.Key = element.Attribute("name").Value;
            this.Value = element.Element("value").Value;
            this.Comment = element.Element("comment").Value;
        }

        /// <summary>
        /// Resource key
        /// </summary>
        public string Key { get; set; }
        
        /// <summary>
        /// Resource value
        /// </summary>
        public string Value { get; set; }
        
        /// <summary>
        /// Comment...
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// A boolean value to indicate if the translation is approved
        /// </summary>
        public bool Approved { get; set; }
        
        /// <summary>
        /// Converts current ResxElement to XElement (resource file element)
        /// </summary>
        public XElement ToXElement() => new XElement("data", new XAttribute("name", Key),
                                                              new XAttribute($"{XNamespace.Xml + "space"}", "preserve"),
                                                              new XElement("value", Value),
                                                              new XElement("comment", Comment));

        /// <summary>
        /// Determine if two elements are equal
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ResxElement other)
        {
            return Key.Equals(other.Key, StringComparison.OrdinalIgnoreCase);
        }
    }
}
