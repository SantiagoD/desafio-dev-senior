using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// Resumo da rota
    /// </summary>
    public class RouteSummary
    {
        //Tempo total da rota
        public string TotalTime { get; set; }

        /// <summary>
        /// Distância total (m)
        /// </summary>
        public double TotalDistance { get; set; }

        /// <summary>
        /// Custo de combustível
        /// </summary>
        public double GasCost { get; set; }


        /// <summary>
        /// Custo total considerando pedágio
        /// </summary>
        public double TotalCost { get; set; }
    }
}
