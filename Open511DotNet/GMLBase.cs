using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Open511DotNet
{
    public class GmlBase
    {
        private string _srsName;

        [JsonIgnore]
        [XmlAttribute("srsName")]
        public string SrsName
        {
            get { return _srsName ?? (_srsName = "urn:ogc:def:crs:EPSG::4326"); }
            set { _srsName = value; }
        }

        /// <summary>
        /// Gets the (mandatory) type of the <see cref="http://geojson.org/geojson-spec.html#geojson-objects">GeoJSON Object</see>.
        /// </summary>
        /// <value>
        /// The type of the object.
        /// </value>
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [XmlIgnore]
        public string Type { get; set; }
    }
}
