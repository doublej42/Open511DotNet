using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Open511DotNet
{
    public class JurisdictionRoot
    {
        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }
        
        [XmlElement("link")]
        public Link Url { get; set; }
        
    }

    public class Jurisdiction : JurisdictionRoot
    {
        public string Email { get; set; }
    }
    
}
