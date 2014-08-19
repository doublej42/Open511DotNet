using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Open511DotNet;

namespace Open511WebApiDemo.Controllers
{
    public class RootController : ApiController
    {
        // GET: api/Root
        public Root Get()
        {
            var root = new Root { Jurisdictions = new List<JurisdictionRoot>(), Services = new List<Service>() };
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
            var service = new Service { ServiceTypeUrl = ServiceType.Events, Url = new Link("/events/") };
            root.Services.Add(service);
            service = new Service { ServiceTypeUrl = ServiceType.Areas, Url = new Link("/areas/") };
            root.Services.Add(service);
            return root;
        }
    }
}
