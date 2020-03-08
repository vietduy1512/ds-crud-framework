using SEP.Framework.Seedwork.DTO;

namespace SEP.Framework.DAO.DTO
{
    public class CategoryDto : AuditDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
