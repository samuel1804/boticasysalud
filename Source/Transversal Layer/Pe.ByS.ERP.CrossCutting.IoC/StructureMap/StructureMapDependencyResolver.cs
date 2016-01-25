using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StructureMap;

namespace Pe.ByS.ERP.CrossCutting.IoC.StructureMap
{
    public class StructureMapDependencyResolver : IDependencyResolver
    {
        public StructureMapDependencyResolver(IContainer container)
        {
            _container = container;
        }

        private readonly IContainer _container;

        /// <summary>
        /// Obtiene la instancia del tipo de objeto indicado, en base a las configuraciones que se hayan especificado en el Structure Map
        /// </summary>
        /// <param name="serviceType">Tipo del objeto del que se desea una instancia</param>
        /// <returns>Una instancia del objeto requerido</returns>
        public object GetService(Type serviceType)
        {
            object instance = _container.TryGetInstance(serviceType);

            if (instance == null && !serviceType.IsAbstract)
            {
                _container.Configure(c => c.AddType(serviceType, serviceType));
                instance = _container.TryGetInstance(serviceType);
            }

            return instance;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAllInstances(serviceType).Cast<object>();
        }
    }
}
