using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using StructureMap;

namespace Pe.ByS.ERP.Infrastructure.Persistence
{
    public class MessageDispatcher
    {
        public static BlockingCollection<KeyValuePair<int, string>> QueriesQueue =  new BlockingCollection<KeyValuePair<int, string>>();

        public void HandleCommand(Action action)
        {
            var instance = ObjectFactory.GetInstance<DbContext>();
            bool isWebApp = Convert.ToBoolean(ConfigurationManager.AppSettings["IsWebApp"] ?? "true");

            if (isWebApp)
            {
                using (instance)
                {
                    ActionSaveChanges(action, instance);
                }
            }
            else
            {
                ActionSaveChanges(action, instance);
            }
        }

        public T HandleQuery<T>(Func<T> action)
        {
            var local2 = action();
            return local2;
        }

        private static void ActionSaveChanges(Action action, DbContext instance)
        {
            action();

            instance.SaveChanges();
        }
    }
}