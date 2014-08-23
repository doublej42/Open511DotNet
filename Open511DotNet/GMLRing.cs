using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Open511DotNet
{
    public class GmlRing
    {
        [XmlElement("LinearRing", Namespace = "http://www.opengis.net/gml")]
        public GmlLinearRing LinearRing { get; set; }
    }

    public class GmlConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var gmlRing = value as GmlRing;
            if (gmlRing != null && gmlRing.LinearRing != null && gmlRing.LinearRing.PosList != null)
            {
                serializer.Serialize(writer, gmlRing.LinearRing.PosList);
            }
            //throw new NotImplementedException();
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
