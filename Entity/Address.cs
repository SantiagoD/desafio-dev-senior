using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Serializable]
    //Endereço
    public class Address
    {

        
        /// <summary>
        /// Nome da rua/avenida
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Número
        /// </summary>
        public string StreetNumber { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        public string State { get; set; }


    }
}
