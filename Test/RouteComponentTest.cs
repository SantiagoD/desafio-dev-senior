using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business.Component;
using Entity;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class RouteComponentTest
    {
        


        [TestMethod]
        public void Test1()
        {
            RouteComponent component = new RouteComponent();

            var list = new List<Address>() { 
            new Address{City="São Paulo", StreetName="Avenida Paulista", StreetNumber="1000"}, 
            new Address{City="São Paulo", StreetName="Nicola Rollo", StreetNumber="20"} 
            };

            var result = component.getTotalRoute(list, 1);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.TotalDistance > 0);
            Assert.IsTrue(result.GasCost > 0);
            Assert.IsTrue(result.TotalCost > 0);
        }
    }
}
