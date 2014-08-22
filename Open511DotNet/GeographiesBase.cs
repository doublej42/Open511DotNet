using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Open511DotNet
{
    [XmlRoot("open511")]
    public class GeographiesBase : Open511Base
    {
        [XmlArray("geographies")]
        [XmlArrayItem("geography")]
        [JsonProperty("geographies")]
        public List<Geography> Geographies { get; set; }

        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Namespaces = new XmlSerializerNamespaces();

        public GeographiesBase() 
        {
            Namespaces.Add("gml", "http://www.opengis.net/gml");
        }
    }
}
