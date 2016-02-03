using System.Collections.Generic;
using Pe.ByS.ERP.Domain;

namespace Pe.ByS.ERP.Application.Converter
{
    public class EmpleadoConverter
    {
        public static List<KeyValuePair<string, string>> ListToKeyValueList(List<Empleado> empeladoList)
        {
            var list = empeladoList.ConvertAll(p => new KeyValuePair<string, string>(p.Id.ToString(), p.Nombre));
            list.Insert(0, new KeyValuePair<string, string>("", "-- Seleccionar --"));

            return list;
        }
    }
}