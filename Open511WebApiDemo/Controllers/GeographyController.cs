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
            var geography = new Geography();
            geography.Polygon = new GmlPolygon();
            geography.Polygon.Exterior = new GmlRing();
            geography.Polygon.Exterior.LinearRing = new GmlLinearRing();
            geography.Polygon.Exterior.LinearRing.PosList = new GmlPosList();
            geography.Polygon.Exterior.LinearRing.PosList.FromString("45.743558682 -73.515580305 45.744177048 -73.516801183 45.74519912 -73.516754263 45.745477517 -73.516741494 45.746719115 -73.519189578 45.748003618 -73.519343022 45.748595939 -73.520130776 45.749015964 -73.520120827 45.750027519 -73.521934616 45.754234632 -73.529479504 45.777799543 -73.527583233 45.743558682 -73.515580305");
            ret.Geographies.Add(geography);
            return ret;
        }
    }
}
