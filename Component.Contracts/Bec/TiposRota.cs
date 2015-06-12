using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Bec
{
    [DataContract]
    public enum TiposRota
    {
        [EnumMember]
        MaisRapida = 0,
        [EnumMember]
        EvitandoTransito = 23
    }

}
