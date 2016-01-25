using System.ComponentModel.DataAnnotations;

namespace Pe.ByS.ERP.CrossCutting.Common.Attributes
{
    public class FechaValidation : RegularExpressionAttribute
    {
        public FechaValidation()
            : base(GetRegex(false))
        { }

        public FechaValidation(bool incluirHora)
            : base(GetRegex(incluirHora))
        { }

        private static string GetRegex(bool incluirHora)
        {
            return incluirHora
                ? @"^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20|21)\d\d\s([01]?[0-9]|2[0-3]):[0-5][0-9]$"
                : @"^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20|21)\d\d";
        }
    }
}
