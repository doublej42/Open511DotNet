using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open511DotNet
{
    public class RestrictionType : StringEnum
    {
        public static readonly RestrictionType Speed = new RestrictionType("SPEED");
        public static readonly RestrictionType Width = new RestrictionType("WIDTH");
        public static readonly RestrictionType Height = new RestrictionType("HEIGHT");
        public static readonly RestrictionType Weight = new RestrictionType("WEIGHT");
        public static readonly RestrictionType AxleWeight = new RestrictionType("AXLE_WEIGHT");
        

        public RestrictionType()
        {

        }

        public RestrictionType(string restriction)
            : base(restriction)
        {
         
        }
    }
}
