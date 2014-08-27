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
    public class EventsBase :Open511Base
    {
        [XmlArray("events")]
        [XmlArrayItem("event")]
        [JsonProperty("events")]
        public List<Event> Events { get; set; }

        [XmlNamespaceDeclarations]
        [JsonIgnore]
        public XmlSerializerNamespaces Namespaces = new XmlSerializerNamespaces();

        public EventsBase() 
        {
            Namespaces.Add("gml", "http://www.opengis.net/gml");
            Events = new List<Event>();
        }
    }
}
