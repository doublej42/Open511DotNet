using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Open511DotNet
{
    public class GmlPoint: GmlBase
    {
        public GmlPoint()
        {
            Pos = new GmlPos();
        }
        
        public GmlPos Pos { get; set; }
    }


}
