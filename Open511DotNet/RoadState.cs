using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open511DotNet
{
    class RoadState: StringEnum
    {
        public static readonly RoadState Closed = new RoadState("CLOSED");
        public static readonly RoadState SomeLanesClosed = new RoadState("SOME_LANES_CLOSED");
        public static readonly RoadState SingleLaneAlternating = new RoadState("SINGLE_LANE_ALTERNATING");
        public static readonly RoadState AllLanesOpen = new RoadState("ALL_LANES_OPEN");
      

        public RoadState()
        {

        }

        public RoadState(string state)
            : base(state)
        {
         
        }
    }
}
