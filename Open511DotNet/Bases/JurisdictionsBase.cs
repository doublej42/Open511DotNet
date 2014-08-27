using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Open511DotNet
{
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
