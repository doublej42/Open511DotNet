using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Open511DotNet.Elements
{
    public class Attachment : Link
    {

        public Attachment()
        {
            Hreflang = "en";
            Rel = "related";
        }

        [XmlAttribute("type")]
        [JsonProperty("type")]
        public string Type { get; set; }

        [XmlAttribute("length")]
        [JsonProperty("length")]
        public long Length { get; set; }

        //[XmlAttribute("href")]
        //[JsonProperty("url")]
        //public new string Url { get; set; }

        [XmlAttribute("title")]
        [JsonProperty("title")]
        public string Title { get; set; }


        [XmlAttribute("hreflang")]
        [JsonProperty("hreflang")]
        public string Hreflang { get; set; }

        public override void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("url");
            writer.WriteValue(Url);

            writer.WritePropertyName("length");
            writer.WriteValue(Length);

            writer.WritePropertyName("type");
            writer.WriteValue(Type);

            writer.WritePropertyName("title");
            writer.WriteValue(Title);

            writer.WritePropertyName("hreflang");
            writer.WriteValue(Hreflang);

            

            writer.WriteEndObject();
        }

        public override void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            dynamic tmp = serializer.Deserialize(reader);
            if (tmp["url"] != null)
            {
                Url = tmp["url"].Value;
            }
            if (tmp["length"] != null)
            {
                Length = tmp["length"].Value;
            }
            if (tmp["type"] != null)
            {
                Type = tmp["type"].Value;
            }
            if (tmp["title"] != null)
            {
                Title = tmp["title"].Value;
            }
            if (tmp["hreflang"] != null)
            {
                Hreflang = tmp["hreflang"].Value;
            }



        }
    }
}
