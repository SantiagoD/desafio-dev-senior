using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    interface IRouteComponent
    {
        RouteSummary getTotalRoute(List<Address> addressList, int routeType); 
    }
}
