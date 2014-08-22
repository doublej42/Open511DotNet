using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Open511DotNet
{
    


    public class Service: LinkHolder
    {

        [XmlIgnore]
        [JsonProperty("service_type_url")]
        public Link ServiceTypeUrl
        {
            get { return GetLink("service_type"); }
            set
            {
                SetLink("service_type", value.Url);
            }
        }

        [XmlIgnore]
        [JsonProperty("url")]
        public Link Url
        {
            get { return GetLink("self"); }
            set
            {
                SetLink("self", value.Url);
            }
        }

        [XmlArray("supported_versions")]
        [XmlArrayItem("supported_version")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "supportedVersions")]
        public List<SupportedVersion> SupportedVersions { get; set; }
    }
}
