using Contracts.Bec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Component.Model.br.com.maplink.services;
using Component.Model.br.com.maplink.servicesV3;


namespace Component.Model.BC
{
    public class RotasBC
    {
        const string token = "c13iyCvmcC9mzwkLd0LCbCBHcXYD5mUA5m2jNGutNXK6NJc6NJt=";

        public ValoresRotasResposta ObterRota(ConsultaRequisicao consulta)
        {
            ValoresRotasResposta resposta = new ValoresRotasResposta();

            List<string> lista = new List<string>();

            Address addressOrigem = new Address();

            addressOrigem.street = consulta.Origem.Nome;
            addressOrigem.houseNumber = consulta.Origem.Numero;


            Address addressDestino = new Address();

            addressDestino.street = consulta.Destino.Nome;
            addressDestino.houseNumber = consulta.Destino.Numero;


            RouteStop originRoute;

            RouteStop destinationRoute;


            using (AddressFinder addressFinderOrigem = new AddressFinder())
            {
                var getCrossStreetAddressResponse = addressFinderOrigem.getXY(addressOrigem, token);
                var getXYResult = getCrossStreetAddressResponse;
            

                originRoute = new RouteStop
                {
                    //description = "Av Jacu-Pessego/Nova Trabalhadores - São Paulo/SP",
                    description = consulta.Origem.Nome + "," + consulta.Origem.Numero + " - " + consulta.Origem.Cidade + "/" + consulta.Origem.Estado,
                    point = new Component.Model.br.com.maplink.services.Point { x = getXYResult.x, y = getXYResult.y }
                };

            }

            using (AddressFinder addressFinderDestino = new AddressFinder())
            {
                var getCrossStreetAddressResponse = addressFinderDestino.getXY(addressDestino, token);
                var getXYResult = getCrossStreetAddressResponse;

                destinationRoute = new RouteStop
                {
                    description = consulta.Destino.Nome + "," + consulta.Destino.Numero + " - " + consulta.Destino.Cidade + "/" + consulta.Destino.Estado,
                    point = new Component.Model.br.com.maplink.services.Point { x = getXYResult.x, y = getXYResult.y }
                };
            }

            var routes = new[] { originRoute, destinationRoute };

            var routeProximityOptions = new RouteProximityOptions
            {
                language = "portugues",
                vehicle = new Vehicle
                {
                    tankCapacity = 20,
                    averageConsumption = 9,
                    fuelPrice = 3,
                    averageSpeed = 60,
                    tollFeeCat = 2
                },
                radius = 100
            };

            using (var routeProximitySoapClient = new RouteProximity())
            {
                var getRouteProximityResponse = routeProximitySoapClient.getRouteProximity(routes, routeProximityOptions, token);

                lista.Add(
                    string.Format("RouteId: {0}, MapInfo - Url: {1}, Extent - XMin: {2}, YMin: {3}, XMax: {4}, YMax: {5}",
                    getRouteProximityResponse.routeId, getRouteProximityResponse.MapInfo.url,
                    getRouteProximityResponse.MapInfo.extent.XMin, getRouteProximityResponse.MapInfo.extent.YMin,
                    getRouteProximityResponse.MapInfo.extent.XMax, getRouteProximityResponse.MapInfo.extent.YMax)
                );

                getRouteProximityResponse.segDescription
                    .ToList()
                    .ForEach(segmentDescription =>
                    {
                        lista.Add(
                        string.Format(
                            "SegmentDescription - Command: {0}, Description: {1}, City: {2}, State: {3},  PoiRoute: {4}",
                            segmentDescription.command, segmentDescription.description,
                            segmentDescription.city.name, segmentDescription.city.state,
                            segmentDescription.poiRoute)
                        );

                        if (segmentDescription.poiRouteDetails != null)
                            segmentDescription.poiRouteDetails
                                    .ToList()
                                    .ForEach(poiRouteDetail =>
                                            lista.Add(
                                            string.Format(
                                                "POIDetails - Client Id: {0}, Name: {1}, AddressInfo: {2}, Source: {3}, " +
                                                "Latitude: {4}, Longitude: {5}",
                                                poiRouteDetail.clientID, poiRouteDetail.name, poiRouteDetail.addressInfo,
                                                poiRouteDetail.source, poiRouteDetail.point.y, poiRouteDetail.point.x)
                                            ));

                        lista.Add(
                        string.Format(
                            "TollFeeDetails - Price: {0}, PricePerAxle: {1}, Distance: {2}, " +
                            "CumulativeDistance: {3}, Latitude: {4}, Longitude: {5}",
                            segmentDescription.tollFeeDetails.price,
                            segmentDescription.tollFeeDetails.pricePerAxle, segmentDescription.distance,
                            segmentDescription.cumulativeDistance, segmentDescription.point.y,
                            segmentDescription.point.x)
                        );
                    });

                lista.Add(
                string.Format(
                    "RouteTotals - TotalDistance: {0}, TotalTime: {1}, TotalFuelUsed: {2}, TotalTollFeeCost: {3}, TotalFuelCost: {4}, " +
                    "TotalCost: {5}, TaxiFarel1: {6}, TaxiFare2: {7}",
                    getRouteProximityResponse.routeTotals.totalDistance, getRouteProximityResponse.routeTotals.totalTime,
                    getRouteProximityResponse.routeTotals.totalFuelUsed, getRouteProximityResponse.routeTotals.totaltollFeeCost,
                    getRouteProximityResponse.routeTotals.totalfuelCost, getRouteProximityResponse.routeTotals.totalCost,
                    getRouteProximityResponse.routeTotals.taxiFare1, getRouteProximityResponse.routeTotals.taxiFare2)
                );

                getRouteProximityResponse.routeSummary
                    .ToList()
                    .ForEach(routeSummary =>
                            lista.Add(
                            string.Format(
                                "RouteSummary - Description: {0}, Distance: {1}, Point - Longitude: {2}, Latitude: {3}",
                                routeSummary.description, routeSummary.distance, routeSummary.point.x, routeSummary.point.y)
                            ));

                lista.Add(
                string.Format(
                    "RoadType - TwoLaneHighway: {0}, SecondLaneUnderConstruction: {1}, OneLaneRoadway: {2}, " +
                    "PavingWorkInProgress: {3}, DirtRoad: {4}, RoadwayInPoorConditions: {5}, Ferry: {6}",
                    getRouteProximityResponse.roadType.twoLaneHighway, getRouteProximityResponse.roadType.secondLaneUnderConstruction,
                    getRouteProximityResponse.roadType.oneLaneRoadway, getRouteProximityResponse.roadType.pavingWorkInProgress,
                    getRouteProximityResponse.roadType.dirtRoad, getRouteProximityResponse.roadType.roadwayInPoorConditions,
                    getRouteProximityResponse.roadType.ferry)
                );

                resposta.DistanciaTotal = getRouteProximityResponse.routeTotals.totalDistance.ToString();
                resposta.CustoTotal = getRouteProximityResponse.routeTotals.totalfuelCost.ToString();
                resposta.DistanciaTotal = getRouteProximityResponse.routeTotals.totalDistance.ToString();
                resposta.TempoTotal = getRouteProximityResponse.routeTotals.totalTime;
            }

            return resposta;
        }
    }
}
