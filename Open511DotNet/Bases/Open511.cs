using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Open511DotNet
{
    public static class Open511
    {
        public static string Serialize(object obj)
        {
            var xws = new XmlWriterSettings { OmitXmlDeclaration = true, CloseOutput = false, CheckCharacters = false };
            var x = new XmlSerializer(obj.GetType());
            var sww = new StringWriter();
            var writer = XmlWriter.Create(sww, xws);
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            ns.Add("gml", "http://www.opengis.net/gml");
            x.Serialize(writer, obj, ns);
            return sww.ToString();
        }
    }

    [XmlRoot("open511")] // not actually inherited. 
    public abstract class Open511Base
    {
        private string _lang;
        private string _base;
        private string _version;
        
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
        public string Version
        {
            get { return _version ?? (_version = "v0"); }
            set { _version = value; }
        }


        [XmlIgnore]
        [JsonProperty("meta")]
        private Dictionary<string, string> Meta
        {
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
