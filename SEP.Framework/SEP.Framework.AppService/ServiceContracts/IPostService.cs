using SEP.Framework.DAO.DTO;
using SEP.Framework.Seedwork.ServiceContracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP.Framework.AppService.ServiceContracts
{
    public interface IPostService : IService
    {
        Task<PostDto> GetPostByIdAsync(int id);
        Task<List<PostDto>> GetAllPostAsync();
        Task<List<PostDto>> GetAllPostByCategoryId(int categoryId);
        IOrderedQueryable<PostDto> GetAllPostByCategoryIdDescendingQuery(int categoryId);
        IOrderedQueryable<PostDto> GetAllPostDescendingQuery();
        bool IsExist(int id);
        Task<int> AddAsync(PostDto dto);
        Task<int> UpdateAsync(PostDto dto);
        Task<int> RemoveAsync(int id);
    }
}
