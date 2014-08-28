using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Open511DotNet.Bases
{
    public class RoadRestriction
    {
        [XmlElement("restriction_type")]
        [JsonProperty("restriction_type")]
        public RestrictionType RestrictionType { get; set; }

        [XmlElement("value")]
        [JsonProperty("value")]
        public double Value { get; set; }
    }
}
