using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Open511DotNet
{

    [JsonConverter(typeof(LinkSerializer))]
    public class Link
    {
        public Link()
        {
            
        }

        public Link(string url, string rel = "self")
        {
            Url = url;
            Rel = rel;
        }

        [XmlAttribute("rel")]
        [JsonIgnore]
        public string Rel { get; set; }
        
        [XmlAttribute("href")]
        public string Url { get; set; }
    }

    public class LinkSerializer: JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var link = value as Link;

            //writer.WriteStartObject();
            //writer.WritePropertyName(serializer);
            if (link != null)
            {
                serializer.Serialize(writer, link.Url);
            }
            //writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (Link);
        }
    }
}
