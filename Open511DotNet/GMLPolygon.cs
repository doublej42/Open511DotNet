using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Open511DotNet
{
    [JsonConverter(typeof(GmlPolygonConverter))]
    public class GmlPolygon : GmlBase
    {
        public GmlPolygon()
        {
            Type = "Polygon";
        }

        [XmlElement("exterior", Namespace = "http://www.opengis.net/gml")]
        public GmlRing Exterior { get; set; }

        [XmlElement("interior", Namespace = "http://www.opengis.net/gml")]
        public GmlRing Interior { get; set; }
    }

    public class GmlPolygonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var polygon = value as GmlPolygon;
            if (polygon != null)
            {
                if (polygon.Exterior != null)
                {
                    serializer.Serialize(writer, polygon.Exterior);
                }
                if (polygon.Interior != null)
                {
                    serializer.Serialize(writer, polygon.Interior);
                }
            }

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(GmlPolygon);
        }
    }
}
