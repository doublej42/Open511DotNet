﻿using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Open511DotNet
{
    //[XmlRoot("open511")]
    public class Root : Open511Base
    {
        //[XmlElement("jurisdictions")]
        [XmlArray("jurisdictions")]
        [XmlArrayItem("jurisdiction")]
        [JsonProperty("jurisdiction")]
        public List<JurisdictionRoot> Jurisdictions { get; set; }

        [XmlArray("services")]
        [XmlArrayItem("service")]
        public List<Service> Services { get; set; }

     

    }
}
