using System;

namespace SEP.Framework.Seedwork.Domain
{
    public class AuditEntity<TId> : BaseEntity<TId>
    {
        public AuditEntity()
        {
            CreatedDate = DateTime.Now;
        }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
