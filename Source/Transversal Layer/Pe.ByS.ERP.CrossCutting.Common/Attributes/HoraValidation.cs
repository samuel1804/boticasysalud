using System.ComponentModel.DataAnnotations;

namespace Pe.ByS.ERP.CrossCutting.Common.Attributes
{
    public class HoraValidation : RegularExpressionAttribute
    {
        public HoraValidation()
            : base(GetRegex())
        { }

        private static string GetRegex()
        {
            return @"^(?:[01]?[0-9]|2[0-3]):[0-5][0-9]$";
        }
    }
}
