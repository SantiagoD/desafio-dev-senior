using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Bec
{
    
    [DataContract]
    public class RotaRequisicao
    {
        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public string Numero { get; set; }

        [DataMember]
        public string Cidade { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public TiposRota Rota { get; set; }

    }
}
