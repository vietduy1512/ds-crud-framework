using BlogNetCore.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ReflectionIT.Mvc.Paging;
using System.Threading.Tasks;
using SEP.Framework.AppService.ServiceContracts;
using SEP.Framework.MVC.Controllers;

namespace BlogNetCore.MVC.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;

        public CategoryController(IPostService _postService, ICategoryService _categoryService)
        {
            postService = _postService;
            categoryService = _categoryService;
        }

        [Route("Category/{categoryName}-{categoryId}")]
        public async Task<IActionResult> PostListByCategory(string categoryName, int? categoryId, int page = 1)
        {
            if (categoryId.HasValue)
            {
                var query = postService.GetAllPostByCategoryIdDescendingQuery(categoryId.Value);
                var postList = await PagingList.CreateAsync(query, 5, page);
                var category = await categoryService.GetCategoryByIdAsync(categoryId.Value);

                // paging configuration
                postList.Action = "PostListByCategory";
                postList.RouteValue = new RouteValueDictionary(new { categoryId = categoryId });

                PostListByCategoryViewModel model = new PostListByCategoryViewModel
                {
                    PostList = postList,
                    Category = category
                };

                return View(model);
            }
            else
            {
                return NotFound();
            }
        }
    }
}