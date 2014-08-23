using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Open511DotNet
{
    
    public class GmlLinearRing
    {
        [XmlElement("posList", Namespace = "http://www.opengis.net/gml")]
        public GmlPosList PosList { get; set; }
    }

    //public class GmlLinearRingConverter : JsonConverter
    //{
    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override bool CanConvert(Type objectType)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
