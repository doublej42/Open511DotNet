using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Open511DotNet
{
    public static class ServiceType
    {
        public static Link Events = new Link("http://open511.org/services/events/", "service_type");
        public static Link EventsStatic = new Link("http://open511.org/services/events-static", "service_type");
        public static Link Areas = new Link("http://open511.org/services/areas/", "service_type");
        public static Link Cameras = new Link("http://open511.org/services/cameras/", "service_type");
        public static Link Roads = new Link("http://open511.org/services/roads/", "service_type");
        public static Link TrafficSegments = new Link("http://open511.org/services/traffic_segments/", "service_type");
    }

    [JsonConverter(typeof(StringEnumSerializer))]
    public class StringEnum : IXmlSerializable
    {
        protected string Value;

        public StringEnum()
        {
            
        }

        public StringEnum(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        internal string Set(string value)
        {
            return Value = value;
        }

        public static implicit operator StringEnum(string value)
        {
            return new StringEnum(value);
        }

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            Value = reader.ReadElementContentAsString();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteString(Value);
        }

        public Dictionary<string, string> ToDictionary()
        {
            var type = GetType();
            var ret = new Dictionary<string, string>();
            foreach (var propertyInfo in type.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var value = propertyInfo.GetValue(this).ToString();
                var readable = value.Replace('_', ' ').ToLower();
                ret.Add(value, readable);
                
            }
            return ret;
        }
    }

    
    public class StringEnumSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var vtemp = value as StringEnum;

            if (vtemp != null)
            {
                serializer.Serialize(writer, vtemp.ToString());
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var ret = (StringEnum) Activator.CreateInstance(objectType);
            ret.Set(reader.Value.ToString());
            return ret;

        }

        //protected bool TryCast<T>(ref T t, object o)
        //{
        //    if (
        //        o == null
        //        || !typeof(T).IsAssignableFrom(o.GetType())
        //        )
        //        return false;
        //    t = (T)o;
        //    return true;
        //}

        public override bool CanConvert(Type objectType)
        {
            return typeof(StringEnum).IsAssignableFrom(objectType);
        }
    }


}
