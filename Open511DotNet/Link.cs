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


    public abstract class LinkHolder
    {
        private List<Link> _links;

        [XmlElement("link")]
        [JsonIgnore]
        public List<Link> Links
        {
            get { return _links ?? (_links = new List<Link>()); }
            set { _links = value; }
        }

        protected void SetLink(string rel, string url)
        {
            var tempLink = new Link { Url = url, Rel = rel };
            Links.RemoveAll(l => l.Rel == tempLink.Rel); // prevent duplicate rel
            Links.Add(tempLink);
        }

        protected void SetLink(Link link)
        {
            Links.RemoveAll(l => l.Rel == link.Rel); // prevent duplicate rel
            Links.Add(link);
        }

        protected Link GetLink(string rel)
        {
            return Links.FirstOrDefault(l => l.Rel == rel);
        }

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
            var link = new Link();
            link.Url = reader.Value.ToString();
            return link;

        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (Link);
        }
    }
}
