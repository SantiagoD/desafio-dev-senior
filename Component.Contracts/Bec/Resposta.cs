using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Bec
{
    [DataContract]
    public abstract class Resposta
    {
        /// <summary>
        /// Mensagem de retorno da operação
        /// </summary>
        [DataMember]
        public string Mensagem { get; set; }

        /// <summary>
        /// Indicador de sucesso ou falha
        /// </summary>
        [DataMember]
        public bool Sucesso { get; set; }

        /// <summary>
        /// Codigo de retorno
        /// </summary>
        [DataMember]
        public int CodigoStatus { get; set; }
    }
}
