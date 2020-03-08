using SEP.Framework.Seedwork.DTO;

namespace SEP.Framework.DAO.DTO
{
    public class CommentDto : AuditDto<int>
    {
        public string Content { get; set; }
        public int? UserId { get; set; }
        public int? PostId { get; set; }
        public string PostCategory { get; set; }
        public string PostTitle { get; set; }
    }
}
