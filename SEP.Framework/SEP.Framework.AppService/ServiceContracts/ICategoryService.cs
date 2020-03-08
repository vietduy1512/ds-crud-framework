using SEP.Framework.DAO.DTO;
using SEP.Framework.Seedwork.ServiceContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEP.Framework.AppService.ServiceContracts
{
    public interface ICategoryService : IService
    {
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task<List<CategoryDto>> GetAllCategoryAsync();
        bool IsExist(int id);
        Task<int> AddAsync(CategoryDto dto);
        Task<int> UpdateAsync(CategoryDto dto);
        Task<int> RemoveAsync(int id);
    }
}
