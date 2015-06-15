using Business.Component;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RouteAPI.Controllers
{
    public class RouteController : ApiController
    {
        // GET api/route/5
        public RouteSummary GetRouteInformation(List<Address> addressList, int routeType)
        {
            return new RouteComponent().getTotalRoute(addressList, routeType);
        }
    }
}
