using System.Collections.Generic;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Application.Converter
{
    public class SucursalConverter
    {
        public static List<KeyValuePair<string, string>> ListToKeyValueList(List<Sucursal> sucursalList)
        {
            var list = sucursalList.ConvertAll(p => new KeyValuePair<string, string>(p.Id.ToString(), p.Nombre));
            list.Insert(0, new KeyValuePair<string, string>("", "-- Seleccionar --"));

            return list;
        }
    }
}