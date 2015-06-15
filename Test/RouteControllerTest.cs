using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entity;
using System.Collections.Generic;
using Business.Component;
using RouteAPI.Controllers;

namespace Test
{
    [TestClass]
    public class RouteControllerTest
    {
        [TestMethod]
        public void GetRouteInformationTest()
        {
            var list = new List<Address>() { 
            new Address{City="São Paulo", StreetName="Avenida Paulista", StreetNumber="1000"}, 
            new Address{City="São Paulo", StreetName="Nicola Rollo", StreetNumber="20"} 
            };

            var component = new RouteComponent().getTotalRoute(list, 1);
            var controller = new RouteController();

            var result = controller.GetRouteInformation(list,1) as RouteSummary;
            Assert.AreEqual(component.TotalCost, result.TotalCost);

        }

        
    }
}
