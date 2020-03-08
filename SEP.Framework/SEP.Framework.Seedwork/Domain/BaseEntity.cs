using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEP.Framework.Seedwork.Domain
{
    public abstract class BaseEntity<TId>
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public virtual TId Id { get; set; }
    }
}
