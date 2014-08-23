using System;
using System.Collections.Generic;
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
                if (geography.Point != null)
                {
                    serializer.Serialize(writer, geography.Point);        
                }
                else if(geography.Polygon != null)
                {
                    serializer.Serialize(writer, geography.Polygon);
                }
            }
            
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Geography);
        }
    }
}
