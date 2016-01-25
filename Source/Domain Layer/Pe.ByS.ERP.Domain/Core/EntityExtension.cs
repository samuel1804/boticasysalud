using System.ComponentModel.DataAnnotations;

namespace Pe.ByS.ERP.Domain.Core
{
    public class EntityExtension<TId> : Entity<TId>
    {
        [MaxLength(800)]
        public string Justificacion { get; set; }
    }
}
