using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Bec
{
    [DataContract]
    public class ConsultaRequisicao
    {
        [DataMember]
        public RotaRequisicao Origem { get; set; }

        [DataMember]
        public RotaRequisicao Destino { get; set; }
    }
}
