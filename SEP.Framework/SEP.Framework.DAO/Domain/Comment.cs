using SEP.Framework.Seedwork.Domain;
using SEP.Framework.Seedwork.Identity;
using System.ComponentModel.DataAnnotations;

namespace SEP.Framework.DAO.Domain
{
    public class Comment : AuditEntity<int>
    {
        [Required, StringLength(1000)]
        public string Content { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public int? PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
