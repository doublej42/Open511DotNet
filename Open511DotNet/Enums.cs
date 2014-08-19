using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public sealed class DistanceUnit
    {

        private readonly string _unit;



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

    }
}
