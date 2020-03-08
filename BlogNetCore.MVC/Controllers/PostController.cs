using SEP.Framework.Seedwork.ServiceContracts;
using BlogNetCore.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;
using System.Threading.Tasks;
using SEP.Framework.AppService.ServiceContracts;
using SEP.Framework.MVC.Controllers;

namespace BlogNetCore.MVC.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;

        public PostController(IPostService _postService, ICategoryService _categoryService)
        {
            postService = _postService;
            categoryService = _categoryService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var query = postService.GetAllPostDescendingQuery();
            var postList = await PagingList.CreateAsync(query, 5, page);

            PostIndexViewModel model = new PostIndexViewModel
            {
                PostList = postList
            };

            return View(model);
        }

        [Route("Post/{postSlug}-{postId}")]
        public async Task<IActionResult> Details(int? postId, string postSlug)
        {
            if (postId == null || postSlug == null)
            {
                return NotFound();
            }

            var post = await postService.GetPostByIdAsync(postId.Value);
            if (post == null)
            {
                return NotFound();
            }

            PostDetailsViewModel model = new PostDetailsViewModel { Post = post };
            return View(model);
        }
    }
}
