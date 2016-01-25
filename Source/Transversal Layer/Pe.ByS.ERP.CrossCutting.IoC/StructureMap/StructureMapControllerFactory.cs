using System;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace Pe.ByS.ERP.CrossCutting.IoC.StructureMap
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// Metodo que Crea las instancias en base al tipo de controlador especificado
        /// </summary>
        /// <param name="requestContext">Contexto para determinar el controlador al que se está invocando</param>
        /// <param name="controllerType">Tipo del controlador que se está invocando</param>
        /// <returns>Instancia del controlador requerido</returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType != null)
                return ObjectFactory.GetInstance(controllerType) as IController;
            return null;
        }
    }
}
