using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open511DotNet
{
    public class EventType : StringEnum
    {
        public static readonly EventType Construction = new EventType("CONSTRUCTION");
        public static readonly EventType SpecialEvent = new EventType("SPECIAL_EVENT");
        public static readonly EventType Incident = new EventType("INCIDENT");
        public static readonly EventType WeatherCondition = new EventType("WEATHER_CONDITION");
        public static readonly EventType RoadCondition = new EventType("ROAD_CONDITION");


        public EventType()
        {

        }

        public EventType(string type)
            : base(type)
        {
         
        }
    }
}
