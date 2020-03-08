using SEP.Framework.DAO.DTO;
using SEP.Framework.Seedwork.ServiceContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEP.Framework.AppService.ServiceContracts
{
    public interface ICommentService : IService
    {
        Task<CommentDto> GetPostByIdAsync(int id);
        Task<List<CommentDto>> GetAllCommentAsync();
        Task<int> AddAsync(CommentDto dto);
        Task<int> RemoveAsync(int id);
    }
}
