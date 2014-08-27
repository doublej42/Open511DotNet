using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Open511DotNet
{
    public class JurisdictionRoot : LinkHolder
    {
        [XmlElement("id")]
        [JsonProperty("id")]
        public string Id { get; set; }

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
    }

    public class Jurisdiction : JurisdictionRoot
    {
        private DistanceUnit _distanceUnit;

        public Jurisdiction()
        {
            Languages = new List<string>();
        }

        

        [XmlIgnore]
        [JsonProperty("description_url")]
        public Link DescriptionUrl
        {
            get { return GetLink("description"); }
            set
            {
                SetLink("description", value.Url);
            }
        }


        [XmlElement("phone")]
        [JsonProperty("phone")]
        public string Phone { get; set; }

        [XmlElement("description")]
        [JsonProperty("description")]
        public string Description { get; set; }


        [XmlIgnore]
        [JsonProperty("geography_url")]
        public Link Geography
        {
            get { return GetLink("geography"); }
            set
            {
                SetLink("geography", value.Url);
            }
        }

        [XmlElement("timezone")]
        [JsonProperty("timezone")]
        public string TimeZone { get; set; }

        [XmlElement("distance_unit")]
        [JsonProperty("distance_unit")]
        public DistanceUnit DistanceUnit
        {
            get { return _distanceUnit; }
            set { _distanceUnit = value; }
        }


        [XmlIgnore]
        [JsonProperty("license_url")]
        public Link License
        {
            get { return GetLink("license"); }
            set
            {
                SetLink("license", value.Url);
            }
        }

        [XmlElement("email")]
        [JsonProperty("email")]
        public string Email { get; set; }

        [XmlArray("languages")]
        [XmlArrayItem("language",DataType = "string")]
        [JsonProperty("languages")]
        public List<string> Languages { get; set; }


    
    }

    [XmlRoot("open511")]
    public class JurisdictionsBase : Open511Base
    {
        private List<Jurisdiction> _jurisdictions;

        [XmlArray("jurisdictions")]
        [XmlArrayItem("jurisdiction")]
        [JsonProperty("jurisdictions")]
        public List<Jurisdiction> Jurisdictions
        {
            get { return _jurisdictions ?? (_jurisdictions = new List<Jurisdiction>()); }
            set { _jurisdictions = value; }
        }
    }
    
}
