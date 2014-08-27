using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Open511DotNet
{
    class Road :LinkHolder
    {
        [XmlElement("name")]
        [JsonProperty("name")]
        public string Name { get; set; }

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

        [XmlElement("from")]
        [JsonProperty("from")]
        public string From { get; set; }


        [XmlElement("to")]
        [JsonProperty("to")]
        public string To { get; set; }


        [XmlElement("to")]
        [JsonProperty("to")]
        public string State { get; set; }


    }
}
