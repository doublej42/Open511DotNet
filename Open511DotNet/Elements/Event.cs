using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Open511DotNet
{
    public class Event : LinkHolder
    {
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

        [XmlIgnore]
        [JsonProperty("jurisdiction")]
        public Link Jurisdiction
        {
            get { return GetLink("jurisdiction"); }
            set
            {
                SetLink("jurisdiction", value.Url);
            }
        }

        [XmlElement("id")]
        [JsonProperty("id")]
        public string Id { get; set; }

        [XmlElement("status")]
        [JsonProperty("status")]
        public EventStatus Status { get; set; }

        [XmlElement("headline")]
        [JsonProperty("headline")]
        public string Headline { get; set; }

        [XmlElement("event_type")]
        [JsonProperty("event_type")]
        public EventType EventType { get; set; }

        [XmlElement("severity")]
        [JsonProperty("severity")]
        public EventSeverity Severity { get; set; }

        [XmlElement("geography")]
        [JsonProperty("geography")]
        public Geography Geography { get; set; }

        [XmlElement("created")]
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [XmlElement("updated")]
        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        [XmlElement("timezone")]
        [JsonProperty("timezone")]
        public string TimeZone { get; set; }

        [XmlElement("description")]
        [JsonProperty("description")]
        public string Description { get; set; }

        [XmlArray("event_subtypes")]
        [XmlArrayItem("event_subtype")]
        [JsonProperty("event_subtypes")]
        public List<EventSubType> Subtypes { get; set; }

        [XmlElement("certainty")]
        [JsonProperty("certainty")]
        public EventCertainty Certainty { get; set; }

        [XmlArray("grouped_events")]
        [XmlArrayItem("link")]
        [JsonProperty("grouped_events")]
        public List<Link> GroupedEvents { get; set; }

        [XmlElement("detour")]
        [JsonProperty("detour")]
        public string Detour { get; set; }

        [XmlArray("roads")]
        [XmlArrayItem("road")]
        [JsonProperty("roads")]
        public List<EventRoad> Roads { get; set; }


        [XmlElement("schedule")]
        [JsonProperty("schedule")]
        public EventSchedule Schedule { get; set; }



    }
}
