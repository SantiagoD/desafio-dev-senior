using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Bec
{
    [DataContract]
    public class ValoresRotasResposta : Resposta
    {
        [DataMember]
        public string TempoTotal { get; set; }

        [DataMember]
        public string DistanciaTotal { get; set; }

        [DataMember]
        public string CustoCombustivel { get; set; }

        [DataMember]
        public string CustoTotal { get; set; }

    }
}
