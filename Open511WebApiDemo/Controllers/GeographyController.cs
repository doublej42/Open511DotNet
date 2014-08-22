using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Open511DotNet;

namespace Open511WebApiDemo.Controllers
{
    public class GeographyController : ApiController
    {
        public GeographiesBase Get()
        {
            var ret = new GeographiesBase {Geographies = new List<Geography>()};
            var geography = new Geography {Point = new GmlPoint()};
            geography.Point.Pos.Latitude = 49.1500;
            geography.Point.Pos.Longitude = -123.9167;
            ret.Geographies.Add(geography);
          

            return ret;
        }
    }
}
