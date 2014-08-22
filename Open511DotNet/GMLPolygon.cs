using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Open511DotNet
{
    public class GmlPolygon : GmlBase
    {
        
        [XmlElement("exterior")]
        public GmlRing Exterior { get; set; }

        [XmlElement("interior")]
        public GmlRing Interior { get; set; }
    }
}
