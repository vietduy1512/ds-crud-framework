using SEP.Framework.Seedwork.Domain;
using SEP.Framework.Seedwork.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEP.Framework.DAO.Domain
{
    public class Post : AuditEntity<int>
    {
        [Required, StringLength(100)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Slug { get; set; }

        [Required, StringLength(300)]
        public string Description { get; set; }

        [StringLength(100)]
        public string ImagePath { get; set; }

        [Required]
        public string Content { get; set; }

        public int? AuthorId { get; set; }
        public virtual User Author { get; set; }

        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}
