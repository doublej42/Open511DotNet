using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Open511DotNet
{
     [JsonConverter(typeof(GeographyConverter))]
    public class Geography
    {
        [XmlElement("Point", Namespace = "http://www.opengis.net/gml")]
        public GmlPoint Point { get; set;}

        [XmlElement("Polygon", Namespace = "http://www.opengis.net/gml")]
        public GmlPolygon Polygon { get; set; }
    }


    public class GeographyConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var geography = value as Geography;
            if (geography != null)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("type");
                if (geography.Point != null)
                {
                    writer.WriteValue("Point");
                    writer.WritePropertyName("coordinates");
                    serializer.Serialize(writer, geography.Point);

                }
                else if (geography.Polygon != null)
                {
                    writer.WriteValue("Polygon");
                    writer.WritePropertyName("coordinates");
                    serializer.Serialize(writer, geography.Polygon);
                }
                writer.WriteEndObject();
            }
            
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var ret = new Geography();
            //var tmp = reader.TokenType;
            dynamic dynamicGeography = serializer.Deserialize(reader);

            if (dynamicGeography["type"] != null && dynamicGeography["coordinates"] != null)
            {
                var type = dynamicGeography["type"].ToString();
                var newReader = new JsonTextReader(new StringReader(dynamicGeography["coordinates"].ToString()));
                if (type == "Point")
                {
                    ret.Point = serializer.Deserialize<GmlPoint>(newReader);
                }
                if (type == "Polygon")
                {
                    ret.Polygon = serializer.Deserialize<GmlPolygon>(newReader);
                }

            }

            return ret;

        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Geography);
        }
    }
}
