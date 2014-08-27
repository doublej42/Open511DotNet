using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open511DotNet
{
    public class ImpactedSystem : StringEnum
    {
        public static readonly ImpactedSystem Road = new ImpactedSystem("ROAD");
        public static readonly ImpactedSystem Sidewalk = new ImpactedSystem("SIDEWALK");
        public static readonly ImpactedSystem Bikelane = new ImpactedSystem("BIKELANE");
        public static readonly ImpactedSystem Parking = new ImpactedSystem("PARKING");


        public ImpactedSystem()
        {

        }

        public ImpactedSystem(string system)
            : base(system)
        {
         
        }
    }
}
