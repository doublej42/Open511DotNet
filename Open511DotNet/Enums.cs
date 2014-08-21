using System;
using System.Collections.Generic;
using System.Linq;
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

    [Serializable]
    [JsonConverter(typeof(DistanceUnitSerializer))]
    public sealed class DistanceUnit : IXmlSerializable
    {


        private string _unit;

        public DistanceUnit()
        {
           
        }

        public DistanceUnit(string unit)
        {
            _unit = unit;
        }

        public override string ToString()
        {
            return _unit;
        }

        public static readonly DistanceUnit Kilometres = new DistanceUnit("KILOMETRES");

        public static readonly DistanceUnit Miles = new DistanceUnit("MILES");


        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
           _unit = reader.ReadElementContentAsString();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteString(_unit);
        }
    }

    public class DistanceUnitSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var distanceUnit = value as DistanceUnit;

            if (distanceUnit != null)
            {
                serializer.Serialize(writer, distanceUnit.ToString());
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var distanceUnit = new DistanceUnit(reader.Value.ToString());
            return distanceUnit;

        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DistanceUnit);
        }
    }
}
