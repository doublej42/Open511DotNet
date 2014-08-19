using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Open511DotNet
{
    [XmlRoot("open511")]
    public class Root
    {
        private string _lang;
        private string _base;
        private string _version;

        //[XmlElement("jurisdictions")]
        [XmlArray("jurisdictions")]
        [XmlArrayItem("jurisdiction")]
        [JsonProperty("jurisdiction")]
        public List<JurisdictionRoot> Jurisdictions { get; set; }

        [XmlArray("services")]
        [XmlArrayItem("service")]
        public List<Service> Services { get; set; }
        
        [JsonIgnore]
        [XmlAttribute("xml:lang")]
        public string Lang
        {
            get { return _lang ?? (_lang = "en"); }
            set { _lang = value; }
        }

        [JsonIgnore]
        [XmlAttribute("xml:base")]
        public string Base
        {
            get { return _base ?? (_base = "http://api.open511.info/"); }
            set { _base = value; }
        }

        [JsonIgnore]
        [XmlAttribute("version")]
        public string Version {
            get { return _version ?? (_version = "v0"); }
            set { _version = value; }
        }

        [XmlIgnore]
        [JsonProperty("meta")]
        private Dictionary<string, string> Meta {
            get
            {
                var ret = new Dictionary<string, string>();
                ret["version"] = Version;
                return ret;
            }
            set
            {
                if (value.ContainsKey("version"))
                {
                    Version = value["version"];
                }
            } 
        }


        public string SerializeXml()
        {
            return Open511.Serialize(this);
        }

    }
}
