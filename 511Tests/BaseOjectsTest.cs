using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Open511DotNet;

namespace _511Tests
{
    [TestClass]
    public class BaseOjectsTest
    {

        protected Root GRoot; // I am Groot

        protected JurisdictionsBase GJurisdictions;

        protected GeographiesBase GeographiesBase;
        public BaseOjectsTest()
        {
            GRoot = new Root { Jurisdictions = new List<JurisdictionRoot>(), Services = new List<Service>() };
            var jurisdictionRoot = new JurisdictionRoot
            {
                Id = "nanaimo.ca",
                Name = "City of Nanaimo",
                Url = new Link("/api/jurisdiction/nanaimo.ca/")
            };
            GRoot.Jurisdictions.Add(jurisdictionRoot);
            jurisdictionRoot = new JurisdictionRoot
            {
                Id = "mycounty.gov",
                Name = "My County",
                Url = new Link("http://mycounty.gov/open511/jurisdiction/mycounty.gov/")
            };
            GRoot.Jurisdictions.Add(jurisdictionRoot);
            var service = new Service
            {
                ServiceTypeUrl = ServiceType.Events,
                Url = new Link("/events/"),
                SupportedVersions = new List<SupportedVersion> {new SupportedVersion {SupportedversionID = "v0"}}
            };
            GRoot.Services.Add(service);
            service = new Service
            {
                ServiceTypeUrl = ServiceType.Areas,
                Url = new Link("/areas/"),
                SupportedVersions = new List<SupportedVersion> { new SupportedVersion { SupportedversionID = "v0" } }
            };
            GRoot.Services.Add(service);



            //jurisdiction
            GJurisdictions = new JurisdictionsBase();
            var jurisdiction = new Jurisdiction
            {
                Id = "nanaimo.ca",
                Name = "City of Nanaimo",
                Url = new Link("/api/jurisdiction/nanaimo.ca/"),
                Description = "Official road data (construction) for The City of Nanaimo",
                DescriptionUrl = new Link("http://www.nanaimo.ca/"),
                Geography = new Link("/api/geography/nanaimo.ca/"),
                Phone = "250-755-4562",
                License =
                    new Link(
                        "http://http://www.nanaimo.ca/EN/main/departments/information-technology/DataCatalogue/Licence.html"),
                TimeZone = TimeZoneInfo.Local.Id,
                Email = "jeff.jacob@nanaimo.ca",
                DistanceUnit = DistanceUnit.Kilometres,
                Languages = new List<string> {"en"}
            };
            GJurisdictions.Jurisdictions.Add(jurisdiction);




         
        }
        
        [TestMethod]
        public void RootbaseTests()
        {
            var testString = GRoot.SerializeXml();
            Assert.IsFalse(string.IsNullOrEmpty(testString));
            
            var serializer = new XmlSerializer(typeof(Root));
            
            byte[] byteArray = Encoding.ASCII.GetBytes(testString);
            var stream = new MemoryStream(byteArray);

            var newRoot = (Root) serializer.Deserialize(stream);
            Assert.IsTrue(newRoot.Jurisdictions.Count == GRoot.Jurisdictions.Count);
            foreach (var item in GRoot.Services)
            {
                Assert.IsTrue(newRoot.Services.Any(i => i.ServiceTypeUrl.Url == item.ServiceTypeUrl.Url));
                Assert.IsTrue(newRoot.Services.Any(i => i.Url.Url == item.Url.Url));
            }
        }


        [TestMethod]
        public void RootJsonTest()
        {
            var jsonText = JsonConvert.SerializeObject(GRoot);
            var newRoot = JsonConvert.DeserializeObject<Root>(jsonText);
            var json2NdText = JsonConvert.SerializeObject(newRoot);
            Assert.AreEqual(GRoot.Services.Count, newRoot.Services.Count);
            Assert.AreEqual(jsonText, json2NdText);
        }

        [TestMethod]
        public void RootXmlTest()
        {
            var xmlText = GRoot.SerializeXml();
            var serializer = new XmlSerializer(typeof(Root));
            byte[] byteArray = Encoding.ASCII.GetBytes(xmlText);
            var stream = new MemoryStream(byteArray);
            var newRoot = (Root) serializer.Deserialize(stream);
            var xml2NdText = newRoot.SerializeXml();
            Assert.AreEqual(GRoot.Services.Count, newRoot.Services.Count);
            Assert.AreEqual(xmlText, xml2NdText);
        }


        [TestMethod]
        public void JurisdictionJsonTest()
        {
            var jsonText = JsonConvert.SerializeObject(GJurisdictions);
            var newJur = JsonConvert.DeserializeObject<JurisdictionsBase>(jsonText);
            var json2NdText = JsonConvert.SerializeObject(newJur);
            Assert.AreEqual(jsonText, json2NdText);
            Assert.AreEqual(GJurisdictions.Jurisdictions.First().DistanceUnit.ToString(), newJur.Jurisdictions.First().DistanceUnit.ToString());
        }

        [TestMethod]
        public void JurisdictionXmlTest()
        {
            var xmlText = GJurisdictions.SerializeXml();
            var serializer = new XmlSerializer(typeof(JurisdictionsBase));
            byte[] byteArray = Encoding.ASCII.GetBytes(xmlText);
            var stream = new MemoryStream(byteArray);
            var newJur = (JurisdictionsBase)serializer.Deserialize(stream);
            Assert.IsTrue(newJur.Jurisdictions[0].DistanceUnit.ToString() == GJurisdictions.Jurisdictions[0].DistanceUnit.ToString());
            var xml2NdText = newJur.SerializeXml();
            Assert.AreEqual(xmlText, xml2NdText);
            Assert.AreEqual(GJurisdictions.Jurisdictions.First().DistanceUnit.ToString(), newJur.Jurisdictions.First().DistanceUnit.ToString());
        }

       
    }
}
