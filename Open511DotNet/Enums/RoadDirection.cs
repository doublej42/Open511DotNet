using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open511DotNet
{
    public class RoadDirection : StringEnum
    {
          public static readonly RoadDirection North = new RoadDirection("N");
          public static readonly RoadDirection NorthWest = new RoadDirection("NW");
          public static readonly RoadDirection West = new RoadDirection("W");
          public static readonly RoadDirection SouthWest = new RoadDirection("SW");
          public static readonly RoadDirection South = new RoadDirection("S");
          public static readonly RoadDirection SouthEast = new RoadDirection("SE");
          public static readonly RoadDirection East = new RoadDirection("E");
          public static readonly RoadDirection NorthEast = new RoadDirection("NE");
          public static readonly RoadDirection None = new RoadDirection("None");
          public static readonly RoadDirection Both = new RoadDirection("BOTH");
        

        public RoadDirection()
        {

        }

        public RoadDirection(string direction)
            : base(direction)
        {
         
        }
    }
}
