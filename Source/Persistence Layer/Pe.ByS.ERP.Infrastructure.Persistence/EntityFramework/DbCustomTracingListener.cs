using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;

namespace Pe.ByS.ERP.Infrastructure.Persistence.EntityFramework
{
    /// <summary>
    /// Implementation of IDbTracingListener
    /// Class is used for tracing all SQL Queries to the entity framework database
    /// </summary>
    public class DbCustomTracingListener : IDbCommandInterceptor
    {      
        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            //var cadena = command.CommandText;

            //if (cadena.ToUpper().StartsWith("SELECT")) return;

            //var cadenaQuery = command.Parameters.Cast<DbParameter>().Aggregate(cadena,
            //        (current, parametro) => current.Replace(parametro.ParameterName, string.Format("'{0}'", parametro.Value.ToString())));

            //var usuarioActual = (Usuario)System.Web.HttpContext.Current.Session[Constantes.UsuarioSesion];

            //if (MessageDispatcher.QueriesQueue != null)
            //    MessageDispatcher.QueriesQueue.Add(new KeyValuePair<int, string>(usuarioActual.Id, cadenaQuery));
        }

        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
        }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
        }

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
        }
    }
}