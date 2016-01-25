using System.ComponentModel.DataAnnotations;

namespace Pe.ByS.ERP.CrossCutting.Common.Attributes
{
    public class NumberValidation : RegularExpressionAttribute
    {
        public NumberValidation()
            : base(GetRegex())
        { }

        private static string GetRegex()
        {
            return @"[0-9]+";
        }
    }
}
