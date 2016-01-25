using System.Collections.Generic;

namespace Pe.ByS.ERP.CrossCutting.Email.Core
{
    public static class CoreEmail
    {
        public static List<string> RetornarParametros(string contenido)
        {
            string[] listaFiltro = { "@Model." };
            listaFiltro = contenido.Split(listaFiltro, System.StringSplitOptions.RemoveEmptyEntries);
            var parametrosList = new List<string>();
            bool esPrimero = true;
            foreach (string item in listaFiltro)
            {
                string reemplazo = item;
                if (esPrimero)
                {
                    esPrimero = false;
                    continue;
                }

                reemplazo = reemplazo.Replace('<', ' ');
                reemplazo = reemplazo.Replace('>', ' ');
                reemplazo = reemplazo.Replace('\r', ' ');
                reemplazo = reemplazo.Replace('\n', ' ');
                reemplazo = reemplazo.Replace('/', ' ');
                reemplazo = reemplazo.Replace('.', ' ');
                reemplazo = reemplazo.Replace('=', ' ');
                reemplazo = reemplazo.Replace('(', ' ');
                reemplazo = reemplazo.Replace(')', ' ');

                string[] espacioBlanco = { " "};
                string[] nuevalistaFiltro = reemplazo.Split(espacioBlanco, System.StringSplitOptions.RemoveEmptyEntries);
                if (nuevalistaFiltro.Length > 0)
                {
                    if(!parametrosList.Contains(nuevalistaFiltro[0]))
                        parametrosList.Add(nuevalistaFiltro[0]);
                }
                    
            }

            return parametrosList;
        }
    }
}
