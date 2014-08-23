using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Open511DotNet
{
    [JsonConverter(typeof(GmlPosConverter))]
    public class GmlPos : IXmlSerializable
    {
        
        public double Latitude { get; set; }

        public double Longitude { get; set; }
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            var cords = reader.ReadElementContentAsString();
            var cordsSplit = cords.Split(new []{' '});
            double lat, lon;
            double.TryParse(cordsSplit[0], out lat);
            double.TryParse(cordsSplit[1], out lon);
            Latitude = lat;
            Longitude = lon;
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(Latitude + " " + Longitude);
        }
    }


    public class GmlPosConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var gmlPos = value as GmlPos;
            if (gmlPos != null)
            {
                writer.WriteStartArray();
                writer.WriteValue(gmlPos.Longitude);
                writer.WriteValue(gmlPos.Latitude);
                writer.WriteEndArray();
            }

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}
