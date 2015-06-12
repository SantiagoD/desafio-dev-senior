using Component.Model.BC;
using Component.Model.Exception;
using Contracts.Bec;
using Contracts.SI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace Services
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall)]

    public class RotasService : IRotas
    {

        public Contracts.Bec.ValoresRotasResposta BuscaRotas(Contracts.Bec.ConsultaRequisicao consultaRotas)
        {
            ValoresRotasResposta resposta = new ValoresRotasResposta();

            try
            {
                RotasBC rotasBC = new RotasBC();

                resposta =  rotasBC.ObterRota(consultaRotas);
                resposta.Sucesso = true;
            }
            catch (FaultException<RotaException> ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.CodigoStatus = 404;
                resposta.Sucesso = false;
            }
            catch (RotaException ex)
            {
                resposta.CodigoStatus = ex.CodigoStatus;
                resposta.Mensagem = ex.Message;
                resposta.Sucesso = false;
            }
            catch (FaultException ex)
            {
                resposta.Mensagem = "Serviço não disponível no momento, por favor, tente mais tarde.";
                resposta.CodigoStatus = 500;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.CodigoStatus = 500;
                resposta.Sucesso = false;
            }

            return resposta;
        }
    }
}
