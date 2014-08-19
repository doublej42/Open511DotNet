using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Open511DotNet;

namespace Open511WebApiDemo.App_Start
{
    public class JurisdictionController : ApiController
    {

        /// <summary>
        /// No defined behavior so just return all jurisdictions I know about.
        /// </summary>
        /// <returns></returns>
        public JurisdictionsBase Get()
        {
            //jurisdiction
            var jurisdictions = new JurisdictionsBase();
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
                Email = "jeff.jacob@nanaimo.ca"
            };
            jurisdiction.Languages.Add("en");
            jurisdictions.Jurisdictions.Add(jurisdiction);
            return jurisdictions;
        }

        /// <summary>
        /// Grab the matching id from the database and return it.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JurisdictionsBase Get(string id)
        {
            //jurisdiction
            var jurisdictions = new JurisdictionsBase();
            var jurisdiction = new Jurisdiction
            {
                Id = id,
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
                Email = "jeff.jacob@nanaimo.ca"
            };
            jurisdiction.Languages.Add("en");
            jurisdictions.Jurisdictions.Add(jurisdiction);
            return jurisdictions;
        }
    }
}
