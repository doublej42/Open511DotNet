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
using Open511DotNet;

namespace _511Tests
{
    [TestClass]
    public class BaseOjectsTest
    {
        [TestMethod]
        public void Root()
        {
            var root = new Root();
            root.Jurisdictions = new List<JurisdictionRoot>();
            var jurisdictionRoot = new JurisdictionRoot
            {
                Id = "nanaimo.ca",
                Name = "City of Nanaimo",
                Url = new Link("http://www.nanaimo.ca/")
            };
            root.Jurisdictions.Add(jurisdictionRoot);
            jurisdictionRoot = new JurisdictionRoot
            {
                Id = "mycounty.gov",
                Name = "My County",
                Url = new Link("http://mycounty.gov/open511/jurisdiction/mycounty.gov/")
            };
            root.Jurisdictions.Add(jurisdictionRoot);
            root.Services = new List<Service>();
            var service = new Service {ServiceTypeUrl = ServiceType.Events, Url = new Link("/events/")};
            root.Services.Add(service);
            service = new Service { ServiceTypeUrl = ServiceType.Areas, Url = new Link("/areas/") };
            root.Services.Add(service);
            var testString = root.SerializeXml();
            Assert.IsFalse(string.IsNullOrEmpty(testString));
            
            var serializer = new XmlSerializer(typeof(Root));
            
            byte[] byteArray = Encoding.ASCII.GetBytes(testString);
            var stream = new MemoryStream(byteArray);

            var newRoot = (Root) serializer.Deserialize(stream);
            Assert.IsTrue(newRoot.Jurisdictions.Count == root.Jurisdictions.Count);
            foreach (var item in root.Services)
            {
                Assert.IsTrue(newRoot.Services.Any(i => i.ServiceTypeUrl.Url == item.ServiceTypeUrl.Url));
                Assert.IsTrue(newRoot.Services.Any(i => i.Url.Url == item.Url.Url));
            }
        }
    }
}
