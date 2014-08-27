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
                writer.WriteStartArray();
                if (polygon.Exterior != null)
                {
                    serializer.Serialize(writer, polygon.Exterior);
                }
                if (polygon.Interior != null)
                {
                    serializer.Serialize(writer, polygon.Interior);
                }
                writer.WriteEndArray();
            }

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var ret = new GmlPolygon();
            var tempArray = serializer.Deserialize<List<GmlRing>>(reader);
            if (tempArray.Count > 0)
            {
                ret.Exterior = tempArray[0];
            }
            if (tempArray.Count > 1)
            {
                ret.Interior = tempArray[1];
            }
            return ret;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(GmlPolygon);
        }
    }
}
