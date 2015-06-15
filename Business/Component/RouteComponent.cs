using Business.Interface;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Component
{
    public class RouteComponent : IRouteComponent
    {
        /// <summary>
        /// Token de acesso
        /// </summary>
        public static string TOKEN = "c13iyCvmcC9mzwkLd0LCbCBHcXYD5mUA5m2jNGutNXK6NJc6NJt=";

        /// <summary>
        /// Devolve as informações da rota
        /// </summary>
        /// <param name="addressList">Lista de endereços informados</param>
        /// <returns>Estrutura com os detalhes da rota</returns>
        public RouteSummary getTotalRoute(List<Entity.Address> addressList, int routeType)
        {

            //Recuperar as coordenadas dos endereços
            List<RouteProximity.RouteStop> stops = getCoordinates(addressList);

            //Calcular a rota
            RouteSummary routeSummary = calculateRoutes(stops, routeType);

            return routeSummary;
        }

        /// <summary>
        /// Chama o serviço de roterização
        /// </summary>
        /// <param name="stops">Lista de paradas</param>
        /// <param name="routeType">tipo de rota</param>
        /// <returns>resumo da rota</returns>
        private RouteSummary calculateRoutes(List<RouteProximity.RouteStop> stops, int routeType)
        {
            
            var proxy = new RouteProximity.RouteProximitySoapClient();

            var options = new RouteProximity.RouteProximityOptions()
            {
                language = "portugues",
                routeDetails = new RouteProximity.RouteDetails
                {
                    routeType = routeType,
                    descriptionType = 1,
                    optimizeRoute = true
                },
                vehicle = new RouteProximity.Vehicle
                {
                    tankCapacity = 20,
                    averageConsumption = 9,
                    fuelPrice = 3,
                    tollFeeCat = 2,
                    averageSpeed = 60
                }


            };

            var result = proxy.getRouteProximityTotals(stops, options, TOKEN);
            

            return new RouteSummary()
            {
                TotalDistance = result.totalDistance,
                GasCost = result.totalfuelCost,
                TotalTime = result.totalTime,
                TotalCost = result.totalCost
            };
        }

        /// <summary>
        /// Recupera as coordemadas
        /// </summary>
        /// <param name="addressList">lista de endereços</param>
        /// <param name="routeType">tipo de rota</param>
        /// <returns>paradas no formato do serviço de calculo de rotas</returns>
        private List<RouteProximity.RouteStop> getCoordinates(List<Entity.Address> addressList)
        {
            var proxy = new AddressFinder.AddressFinderSoapClient();
            var stopList = new List<RouteProximity.RouteStop>();

            foreach (var address in addressList)
            {
                var point = proxy.getXY(new AddressFinder.Address { city = new AddressFinder.City { name = address.City, state = address.State }, street = address.StreetName, houseNumber = address.StreetNumber }, TOKEN);
                stopList.Add(new RouteProximity.RouteStop() { point = new RouteProximity.Point { x = point.x, y = point.y } });
            }

            return stopList;
        }
    }
}
