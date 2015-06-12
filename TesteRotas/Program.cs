using Contracts.Bec;
using Contracts.SI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace TesteRotas
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceClient<IRotas> serviceRotas = new ServiceClient<IRotas>("BasicHttpBinding_IRotas"))
            {
                ValoresRotasResposta resposta = new ValoresRotasResposta();

                ConsultaRequisicao consultaReq = new ConsultaRequisicao();

                consultaReq.Origem = new RotaRequisicao();

                consultaReq.Origem.Nome = "Rua Bicudo de Brito";
                consultaReq.Origem.Numero = "771";
                consultaReq.Origem.Cidade = "São Paulo";
                consultaReq.Origem.Estado = "SP";

                consultaReq.Destino = new RotaRequisicao();

                consultaReq.Destino.Nome = "Av. Paulista";
                consultaReq.Destino.Numero = "900";
                consultaReq.Destino.Cidade = "São Paulo";
                consultaReq.Destino.Estado = "SP";


                resposta = serviceRotas.Proxy.BuscaRotas(consultaReq);
            }

        }
    }
}
