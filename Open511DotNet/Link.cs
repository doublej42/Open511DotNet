using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Open511DotNet
{
    public class Link
    {
        public Link()
        {
            
        }

        public Link(string url, string rel = "self")
        {
            Url = url;
            Rel = rel;
        }

        [XmlAttribute("rel")]
        public string Rel { get; set; }
        
        [XmlAttribute("href")]
        public string Url { get; set; }
    }
}
