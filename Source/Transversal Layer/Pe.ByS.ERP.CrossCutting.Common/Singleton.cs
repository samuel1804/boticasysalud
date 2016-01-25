using System;
using System.Threading;

namespace Pe.ByS.ERP.CrossCutting.Common
{
    public abstract class Singleton<T> where T : class, new()
    {
        private static T _instancia;
        private static readonly Mutex _mutex = new Mutex();

        public static T Instancia
        {
            get
            {
                try
                {
                    _mutex.WaitOne();
                    if (_instancia == null)
                        _instancia = new T();
                    _mutex.ReleaseMutex();
                }
                catch (Exception)
                {
                    _instancia = new T();
                }

                return _instancia;
            }
        }
    }
}
