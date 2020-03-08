using AutoMapper;
using AutoMapper.QueryableExtensions;
using SEP.Framework.Seedwork.Repository.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP.Framework.DAO.DTO;
using SEP.Framework.DAO.Domain;
using SEP.Framework.AppService.ServiceContracts;

namespace SEP.Framework.AppService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IMapper mapper;

        public CategoryService(IRepository<Category> _categoryRepository, IMapper _mapper)
        {
            categoryRepository = _categoryRepository;
            mapper = _mapper;
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            return await categoryRepository.Query()
                                        .Where(x => x.Id == id)
                                        .ProjectTo<CategoryDto>()
                                        .FirstOrDefaultAsync();
        }

        public async Task<List<CategoryDto>> GetAllCategoryAsync()
        {
            return await categoryRepository.Query()
                                        .OrderByDescending(x => x.Name)
                                        .ProjectTo<CategoryDto>()
                                        .ToListAsync();
        }

        public bool IsExist(int id)
        {
            return categoryRepository.Query().Any(e => e.Id == id);
        }

        public async Task<int> AddAsync(CategoryDto dto)
        {
            var entity = new Category
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description
            };
            categoryRepository.Add(entity);
            return await categoryRepository.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(CategoryDto dto)
        {
            var entity = new Category
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description
            };
            categoryRepository.Update(entity);
            return await categoryRepository.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(int id)
        {
            var category = await categoryRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            categoryRepository.Remove(category);
            return await categoryRepository.SaveChangesAsync();
        }
    }
}
