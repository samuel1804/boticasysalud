using System;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace Pe.ByS.ERP.CrossCutting.IoC.StructureMap
{
    public class StructureMapControllerActivator : IControllerActivator
    {
        public StructureMapControllerActivator(IContainer container)
        {
            _container = container;
        }

        private readonly IContainer _container;

        /// <summary>
        /// Metodo que Crea las instancias en base al tipo de controlador especificado
        /// </summary>
        /// <param name="requestContext">Contexto para determinar el controlador al que se está invocando</param>
        /// <param name="controllerType">Tipo del controlador que se está invocando</param>
        /// <returns>Instancia del controlador requerido</returns>
        public IController Create(RequestContext requestContext, Type controllerType)
        {
            return _container.GetInstance(controllerType) as IController;
        }
    }
}
