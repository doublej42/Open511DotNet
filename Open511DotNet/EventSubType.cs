using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open511DotNet
{
    public class EventSubType : StringEnum
    {
        public static readonly EventSubType Accident = new EventSubType("ACCIDENT");
        public static readonly EventSubType Spill = new EventSubType("SPILL");
        public static readonly EventSubType Obstruction = new EventSubType("OBSTRUCTION");
        public static readonly EventSubType Hazard = new EventSubType("HAZARD");
        public static readonly EventSubType RoadMaintenance = new EventSubType("ROAD_MAINTENANCE");
        public static readonly EventSubType RoadConstruction = new EventSubType("ROAD_CONSTRUCTION");
        public static readonly EventSubType EmergencyMaintenance = new EventSubType("EMERGENCY_MAINTENANCE");
        public static readonly EventSubType PlannedEvent = new EventSubType("PLANNED_EVENT");
        public static readonly EventSubType Crowd = new EventSubType("CROWD");
        public static readonly EventSubType Hail = new EventSubType("HAIL");
        public static readonly EventSubType Thunderstorm = new EventSubType("THUNDERSTORM");
        public static readonly EventSubType HeavyDownpour = new EventSubType("HEAVY_DOWNPOUR");
        public static readonly EventSubType StrongWinds = new EventSubType("STRONG_WINDS");
        public static readonly EventSubType BlowingDust = new EventSubType("BLOWING_DUST");
        public static readonly EventSubType Sandstorm = new EventSubType("SANDSTORM");
        public static readonly EventSubType InsectSwarm = new EventSubType("INSECT_SWARMS");
        public static readonly EventSubType AvalanceHazard = new EventSubType("AVALANCHE_HAZARD");
        public static readonly EventSubType SurfaceWaterHazard = new EventSubType("SURFACE_WATER_HAZARD");
        public static readonly EventSubType Mud = new EventSubType("MUD");
        public static readonly EventSubType LooseGravel = new EventSubType("LOOSE_GRAVEL");
        public static readonly EventSubType OilOnRoadway = new EventSubType("OIL_ON_ROADWAY");
        public static readonly EventSubType Fire = new EventSubType("Fire");
        public static readonly EventSubType SignalLightFailure = new EventSubType("SIGNAL_LIGHT_FAILURE");
        public static readonly EventSubType PartlyIcy = new EventSubType("PARTLY_ICY");
        public static readonly EventSubType IceCovered = new EventSubType("ICE_COVERED");
        public static readonly EventSubType PartlySnowPacked = new EventSubType("PARTLY_SNOW_PACKED");
        public static readonly EventSubType SnowPacked = new EventSubType("SNOW_PACKED");
        public static readonly EventSubType PartlySnowCovered = new EventSubType("PARTLY_SNOW_COVERED");
        public static readonly EventSubType SnowCovered = new EventSubType("SNOW_COVERED");
        public static readonly EventSubType DrifitingSnow = new EventSubType("DRIFTING_SNOW ");
        public static readonly EventSubType PoorVisibility = new EventSubType("POOR_VISIBILITY ");
        public static readonly EventSubType AlmostImpassable = new EventSubType("ALMOST_IMPASSABLE");
        public static readonly EventSubType PassableWithCare = new EventSubType("PASSABLE_WITH_CARE");

        public EventSubType()
        {

        }

        public EventSubType(string status)
            : base(status)
        {

        }
    }
}
