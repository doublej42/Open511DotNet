using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;
using System.Text;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Open511DotNet;
using Open511DotNet.Bases;
using Open511DotNet.Elements;
using Open511DotNet.Geo;

namespace _511Tests
{
    [TestClass]
    public class EventTests
    {
        public EventTests()
        {
            TestObject = new EventsBase();

            //var geography = new Geography
            //{
            //    Polygon =
            //        new GmlPolygon
            //        {
            //            Exterior = new GmlRing { LinearRing = new GmlLinearRing { PosList = new GmlPosList() } }
            //        }
            //};
            //geography.Polygon.Exterior.LinearRing.PosList.FromString("45.743558682 -73.515580305 45.744177048 -73.516801183 45.74519912 -73.516754263 45.745477517 -73.516741494 45.746719115 -73.519189578 45.748003618 -73.519343022 45.748595939 -73.520130776 45.749015964 -73.520120827 45.750027519 -73.521934616 45.754234632 -73.529479504 45.777799543 -73.527583233 45.743558682 -73.515580305");
            var geography = new Geography { LineString = new GmlLineString { PosList = new GmlPosList() } };
            geography.LineString.PosList.FromString("47.33 -71.17 47.36 -71.15 47.35 -71.1 47.4 -71.2");
            var te = new Event
            {
                Url = "http://localhost/api/events/1",
                Jurisdiction = "http://localhost/api/jurisdiction/nanaimo",
                Id = "nanaimo/1",
                Status = EventStatus.Active,
                Headline = "this is my first event",
                EventType = EventType.Construction,
                Severity = EventSeverity.Moderate,
                Created = DateTime.Now.AddDays(1),
                Updated = DateTime.Now,
                TimeZone = TimeZoneInfo.Local.Id,
                Description = "This is my description",
                Subtypes = new List<EventSubType> {EventSubType.InsectSwarm},
                Certainty = EventCertainty.Likely,
                GroupedEvents = new List<Link> {new Link("http://locahost/api/events/2", "related")},
                Detour = "This is a detour",
                Roads = new List<EventRoad>
                {
                    new EventRoad
                    {
                        Name = "Dunsmuir Street",
                        From = "400 block",
                        To = "500 block",
                        State = RoadState.AllLanesOpen,
                        Direction = RoadDirection.Both,
                        LanesClosed = 0,
                        LanesOpen = 2,
                        ImpactedSystems = new List<ImpactedSystem> {ImpactedSystem.Bikelane},
                        Restrictions = new List<RoadRestriction>
                        {
                            new RoadRestriction {RestrictionType = RestrictionType.Speed, Value = 50}
                        }
                    }
                },
                Geography = geography,
                Schedule = new EventSchedule
                {
                    RecurringSchedules = new List<RecurringSchedule>(),
                    ScheduleExceptions = new List<ScheduleException>()
                }
            };
            var re = new RecurringSchedule
            {
                StartDate = new DateTime(2014, 06, 1, 9, 0, 0),
                EndDate = new DateTime(2014, 06, 30, 17, 0, 0),
                Days = new List<DayOfWeek>
                {
                    DayOfWeek.Monday,
                    DayOfWeek.Tuesday,
                    DayOfWeek.Wednesday,
                    DayOfWeek.Thursday,
                    DayOfWeek.Friday
                }
            };
            te.Schedule.RecurringSchedules.Add(re);
            
            var se = new ScheduleException {StartDate = new DateTime(2014, 06, 24), InEffect = false};
            se.EndDate = se.StartDate.AddDays(1);
            te.Schedule.ScheduleExceptions.Add(se);
            te.Schedule.ScheduleIntervals = new List<ScheduleInterval>
            {
                new ScheduleInterval
                {
                    StartDate = new DateTime(2014, 06, 25, 17, 0, 0),
                    EndDate = new DateTime(2014, 06, 26, 6, 0, 0)
                },
                new ScheduleInterval
                {
                    StartDate = new DateTime(2014, 06, 26, 17, 0, 0),
                    EndDate = new DateTime(2014, 06, 27, 6, 0, 0)
                }
            };


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
