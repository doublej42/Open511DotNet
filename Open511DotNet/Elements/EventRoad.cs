using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Open511DotNet.Bases;

namespace Open511DotNet
{
    public class EventRoad :LinkHolder
    {
        [XmlElement("name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [XmlIgnore]
        [JsonProperty("url",NullValueHandling = NullValueHandling.Ignore)]
        public Link Url
        {
            get { return GetLink("self"); }
            set
            {
                SetLink("self", value.Url);
            }
        }

        [XmlElement("from")]
        [JsonProperty("from")]
        public string From { get; set; }


        [XmlElement("to")]
        [JsonProperty("to")]
        public string To { get; set; }


        [XmlElement("state")]
        [JsonProperty("state")]
        public RoadState State { get; set; }

        [XmlElement("direction")]
        [JsonProperty("direction")]
        public RoadDirection Direction { get; set; }

        [XmlElement("lanes_open")]
        [JsonProperty("lanes_open")]
        public int LanesOpen { get; set; }


        [XmlElement("lanes_closed")]
        [JsonProperty("lanes_closed")]
        public int LanesClosed { get; set; }

        [XmlArray("impacted_systems")]
        [XmlArrayItem("impacted_system")]
        [JsonProperty("impacted_systems")]
        public List<ImpactedSystem> ImpactedSystems { get; set; }

        [XmlArray("restrictions")]
        [XmlArrayItem("restriction")]
        [JsonProperty("restrictions")]
        public List<RoadRestriction> Restrictions { get; set; }


    }
}
