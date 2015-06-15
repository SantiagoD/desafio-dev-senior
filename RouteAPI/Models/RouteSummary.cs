using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteAPI.Models
{
    public class RouteSummary
    {
        //Tempo total da rota
        public TimeSpan TotalTime { get; set; }

        /// <summary>
        /// Distância total (m)
        /// </summary>
        public int TotalDistance { get; set; }

        /// <summary>
        /// Custo de combustível
        /// </summary>
        public int GasCost { get; set; }


        /// <summary>
        /// Custo total considerando pedágio.
        /// </summary>
        public int TotalCost { get; set; }
    }
}
