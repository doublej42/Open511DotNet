using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Open511DotNet
{
    public class SupportedVersion
    {
        [XmlElement("supported_version")]
        public string SupportedversionID { get; set; }
    }
}
