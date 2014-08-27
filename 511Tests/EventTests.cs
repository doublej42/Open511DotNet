using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;
using System.Text;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Open511DotNet;

namespace _511Tests
{
    [TestClass]
    public class EventTests
    {
        public EventTests()
        {
           TestObject = new EventsBase();
            var te = new Event();
            te.Url = "http://localhost/api/events/1";
            te.Jurisdiction = "http://localhost/api/jurisdiction/nanaimo";
            te.Id = "nanaimo/1";
            te.Status = EventStatus.Active;
            te.Headline = "this is my first event";
            te.EventType = EventType.Construction;
            te.Severity = EventSeverity.Moderate;
            var geography = new Geography
            {
                Polygon =
                    new GmlPolygon
                    {
                        Exterior = new GmlRing {LinearRing = new GmlLinearRing {PosList = new GmlPosList()}}
                    }
            };
            geography.Polygon.Exterior.LinearRing.PosList.FromString("45.743558682 -73.515580305 45.744177048 -73.516801183 45.74519912 -73.516754263 45.745477517 -73.516741494 45.746719115 -73.519189578 45.748003618 -73.519343022 45.748595939 -73.520130776 45.749015964 -73.520120827 45.750027519 -73.521934616 45.754234632 -73.529479504 45.777799543 -73.527583233 45.743558682 -73.515580305");
            te.Geography = geography;
            te.Created = DateTime.Now.AddDays(1);
            te.Updated = DateTime.Now;
            te.TimeZone = TimeZoneInfo.Local.Id;
            te.Description = "This is my description";
            te.Subtypes = new List<EventSubType> {EventSubType.InsectSwarm};
            te.Certainty = EventCertainty.Likely;
            te.GroupedEvents = new List<Link> {new Link("http://locahost/api/events/2","related")};
            te.Detour = "This is a detour";
            TestObject.Events.Add(te);
        }

        public EventsBase TestObject { get; set; }

        [TestMethod]
        public void BaseXmlText()
        {
            var xmlText = TestObject.SerializeXml();
            var serializer = new XmlSerializer(typeof(EventsBase));
            byte[] byteArray = Encoding.ASCII.GetBytes(xmlText);
            var stream = new MemoryStream(byteArray);
            var newObject = (EventsBase)serializer.Deserialize(stream);
            var xml2NdText = newObject.SerializeXml();
            Assert.AreEqual(xmlText, xml2NdText);
        }



        [TestMethod]
        public void JsonTest()
        {
            var jsonText = JsonConvert.SerializeObject(TestObject);
            var newObj = JsonConvert.DeserializeObject<EventsBase>(jsonText);
            var json2NdText = JsonConvert.SerializeObject(newObj);
            Assert.AreEqual(jsonText, json2NdText);
        }
    }
}
