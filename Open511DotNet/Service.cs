using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Open511DotNet
{
    public static class ServiceType
    {
        public static Link Events = new Link("http://open511.org/services/events/", "service_type");
        public static Link EventsStatic = new Link("http://open511.org/services/events-static", "service_type");
        public static Link Areas = new Link("http://open511.org/services/areas/", "service_type");
        public static Link Cameras = new Link("http://open511.org/services/cameras/", "service_type");
        public static Link Roads = new Link("http://open511.org/services/roads/", "service_type");
        public static Link TrafficSegments = new Link("http://open511.org/services/traffic_segments/", "service_type");
    }


    public class Service
    {
        private List<Link> _links;

        [XmlIgnore]
        [JsonProperty("service_type_url")]
        public Link ServiceTypeUrl
        {
            get { return Links.FirstOrDefault(l => l.Rel == "service_type"); }
            set
            {
                var tempLink = value;
                tempLink.Rel = "service_type";
                Links.RemoveAll(l => l.Rel == tempLink.Rel); // prevent duplicate rel
                Links.Add(tempLink);
            }
        }

        [XmlIgnore]
        [JsonProperty("url")]
        public Link Url
        {
            get { return Links.FirstOrDefault(l => l.Rel == "self"); }
            set
            {
                var tempLink = value;
                tempLink.Rel = "self";
                Links.RemoveAll(l => l.Rel == tempLink.Rel); // prevent duplicate rel
                Links.Add(tempLink);
            }
        }

        [XmlElement("link")]
        [JsonIgnore]
        public List<Link> Links
        {
            get { return _links ?? (_links = new List<Link>()); }
            set { _links = value; }
        }

        [XmlArray("supported_versions")]
        [XmlArrayItem("supported_version")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "supportedVersions")]
        public List<SupportedVersion> SupportedVersions { get; set; }
    }
}
