using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Open511DotNet
{
    public class GmlBase
    {
        private string _srsName;

        [XmlAttribute("srsName")]
        public string SrsName
        {
            get { return _srsName ?? (_srsName = "urn:ogc:def:crs:EPSG::4326"); }
            set { _srsName = value; }
        }
    }
}
