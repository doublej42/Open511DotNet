﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Open511DotNet
{
    public class Geography
    {
        [XmlElement("Point", Namespace = "http://www.opengis.net/gml")]
        public GmlPoint Point { get; set;}
    }
}
