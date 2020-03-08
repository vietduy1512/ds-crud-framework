using System;

namespace SEP.Framework.Seedwork.DTO
{
    public class AuditDto<TId> : BaseDto<TId>
    {
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
