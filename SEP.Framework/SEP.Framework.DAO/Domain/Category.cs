using SEP.Framework.Seedwork.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEP.Framework.DAO.Domain
{
    public class Category : AuditEntity<int>
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }
    }
}
