
using System;

namespace Pe.ByS.ERP.CrossCutting.Common
{
    public class LogicException : Exception
    {
        private readonly string mensaje;

        public override string Message
        {
            get { return mensaje; }
        }

        public LogicException(object source, Exception exception)
        {
            mensaje = string.Format("Error en {0}: {1}", source.GetType().Name, exception.Message);
        }
    }
}
