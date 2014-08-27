using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Open511DotNet
{

    public sealed class DistanceUnit : StringEnum
    {
        public static readonly DistanceUnit Kilometres = new DistanceUnit("KILOMETRES");
        public static readonly DistanceUnit Miles = new DistanceUnit("MILES");

        public DistanceUnit()
        {

        }

        public DistanceUnit(string unit): base(unit)
        {
         
        }
    }
}
