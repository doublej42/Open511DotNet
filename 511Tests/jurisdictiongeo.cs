using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Open511DotNet;

namespace _511Tests
{
    [TestClass]
    public class Jurisdictiongeo
    {
        public Jurisdictiongeo()
        {
            //GGeographiesBase

            GGeographiesBase = new GeographiesBase { Geographies = new List<Geography>() };
            var geography = new Geography();
            geography.Polygon = new GmlPolygon();
            geography.Polygon.Exterior = new GmlRing();
            geography.Polygon.Exterior.LinearRing = new GmlLinearRing();
            geography.Polygon.Exterior.LinearRing.PosList = new GmlPosList();
            geography.Polygon.Exterior.LinearRing.PosList.FromString("45.743558682 -73.515580305 45.744177048 -73.516801183 45.74519912 -73.516754263 45.745477517 -73.516741494 45.746719115 -73.519189578 45.748003618 -73.519343022 45.748595939 -73.520130776 45.749015964 -73.520120827 45.750027519 -73.521934616 45.754234632 -73.529479504 45.777799543 -73.527583233 45.743558682 -73.515580305");
            //geography.Polygon.Exterior.LinearRing.PosList.FromString("1 2 3 4 5 6 7 8");
            GGeographiesBase.Geographies.Add(geography);
            

        }

        public GeographiesBase GGeographiesBase { get; set; }

        [TestMethod]
        public void GeographiesBaseXmlText()
        {
            var xmlText = GGeographiesBase.SerializeXml();
            var serializer = new XmlSerializer(typeof(GeographiesBase));
            byte[] byteArray = Encoding.ASCII.GetBytes(xmlText);
            var stream = new MemoryStream(byteArray);
            var newObject = (GeographiesBase)serializer.Deserialize(stream);
            var xml2NdText = newObject.SerializeXml();
            Assert.AreEqual(xmlText, xml2NdText);
        }



        [TestMethod]
        public void JurisdictionJsonTest()
        {
            var jsonText = JsonConvert.SerializeObject(GGeographiesBase);
            var newObj = JsonConvert.DeserializeObject<GeographiesBase>(jsonText);
            var json2NdText = JsonConvert.SerializeObject(newObj);
            Assert.AreEqual(jsonText, json2NdText);
            Assert.AreEqual(GGeographiesBase.Geographies[0].Polygon.Exterior.LinearRing.PosList.Points[0].Latitude, newObj.Geographies[0].Polygon.Exterior.LinearRing.PosList.Points[0].Latitude);
        }
    }
}
