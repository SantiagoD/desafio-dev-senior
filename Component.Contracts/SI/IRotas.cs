using Contracts.Bec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.SI
{
     [ServiceContract]
    public interface IRotas
    {
         [OperationContract]

         ValoresRotasResposta BuscaRotas(ConsultaRequisicao consultaRotas);
    }
}
