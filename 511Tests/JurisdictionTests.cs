using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Open511DotNet;

namespace _511Tests
{
    [TestClass]
    public class JurisdictionTests
    {
        protected JurisdictionsBase GJurisdictions;

        public JurisdictionTests()
        {
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
                Languages = new List<string> { "en" }
            };
            GJurisdictions.Jurisdictions.Add(jurisdiction);



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
