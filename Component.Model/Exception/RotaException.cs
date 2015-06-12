using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Component.Model.Exception
{
    [Serializable]
    public class RotaException : ApplicationException, ISerializable
    {
        private const string mensagemPadrao = "Ocorreu um erro genérico no serviço Consulta de Rota";

        public virtual int CodigoStatus
        {
            get
            {
                return 400; //TODO
            }
        }

        public string MensagemLog
        {
            get;
            protected set;
        }

        public RotaException()
            : base(mensagemPadrao)
        {
            MensagemLog = mensagemPadrao;
        }

        public RotaException(System.Exception innerException)
            : base(mensagemPadrao, innerException)
        {
            MensagemLog = mensagemPadrao;
        }


        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            base.GetObjectData(info, context);

            info.AddValue("MensagemLog", MensagemLog);
        }

    }
}
