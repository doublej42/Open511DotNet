using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open511DotNet
{
    public class EventCertainty : StringEnum
    {
        public static readonly EventCertainty Observed = new EventCertainty("OBSERVED");
        public static readonly EventCertainty Likely = new EventCertainty("LIKELY");
        public static readonly EventCertainty Possible = new EventCertainty("POSSIBLE");
        public static readonly EventCertainty Unknown = new EventCertainty("UNKNOWN");

      

        public EventCertainty()
        {

        }

        public EventCertainty(string certainty)
            : base(certainty)
        {
         
        }
    }
}
