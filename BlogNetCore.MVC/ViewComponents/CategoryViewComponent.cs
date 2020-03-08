using AutoMapper.QueryableExtensions;
using SEP.Framework.Seedwork.Repository.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using SEP.Framework.DAO.Domain;
using SEP.Framework.DAO.DTO;
using SEP.Framework.MVC.ViewComponents;

namespace BlogNetCore.MVC.ViewComponents
{
    public class CategoryListViewComponent : BaseViewComponent
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoryListViewComponent(IRepository<Category> _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await categoryRepository.Query()
                                                .ProjectTo<CategoryDto>()
                                                .OrderByDescending(x => x.Name)
                                                .ToListAsync();
            return View("CategoryList", categories);
        }
    }
}
