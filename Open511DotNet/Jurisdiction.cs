using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Open511DotNet
{
    public class JurisdictionRoot
    {
        [XmlElement("id")]
        [JsonProperty("id")]
        public string Id { get; set; }

        [XmlElement("name")]
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [XmlElement("link")]
        [JsonProperty("url")]
        public Link Url { get; set; }
        
    }

    public class Jurisdiction : JurisdictionRoot
    {
        public string Email { get; set; }
    }
    
}
