using BlogNetCore.Common.Constants;
using BlogNetCore.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;
using SEP.Framework.DAO.DTO;
using SEP.Framework.Utils.Helpers;
using SEP.Framework.AppService.ServiceContracts;
using SEP.Framework.MVC.Controllers;

namespace BlogNetCore.MVC.Controllers
{
    [Authorize]
    public class ManageController : BaseController
    {
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;
        private readonly ICommentService commentService;

        public ManageController(IPostService _postService, ICategoryService _categoryService, ICommentService _commentService)
        {
            postService = _postService;
            categoryService = _categoryService;
            commentService = _commentService;
        }

        public async Task<IActionResult> PostManage()
        {
            var postList = await postService.GetAllPostAsync();
            return View(postList);
        }

        public async Task<IActionResult> CategoryManage()
        {
            var categoryList = await categoryService.GetAllCategoryAsync();
            return View(categoryList);
        }

        public async Task<IActionResult> CommentManage()
        {
            var commentList = await commentService.GetAllCommentAsync();
            return View(commentList);
        }

        #region Post Managing

        [Route("Manage/Post/Create")]
        public async Task<IActionResult> CreatePost()
        {
            var categories = await categoryService.GetAllCategoryAsync();
            PostCreateViewModel model = new PostCreateViewModel { Categories = categories };
            return View("Post/Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Manage/Post/Create")]
        public async Task<IActionResult> CreatePost([Bind("Title,Description,Content,Id,AuthorId,CategoryId,CategoryName")] PostDto post, IFormFile uploaded_image)
        {
            if (ModelState.IsValid)
            {
                // Save image to server
                string imageName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(uploaded_image.FileName);
                var path = Path.Combine(
                       Directory.GetCurrentDirectory(), PathConstant.PostThumbnailPath,
                       imageName);
                if (uploaded_image.Length > 0)
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await uploaded_image.CopyToAsync(stream);
                    }
                }

                post.Slug = RegexHelper.CreateSlug(post.Title);
                post.ImagePath = PathConstant.UploadedImagePath + imageName;

                await postService.AddAsync(post);
                return RedirectToAction("PostManage", "Manage");
            }
            return View("Post/Create", post);
        }

        [Route("Manage/Post/Edit/{postId}")]
        public async Task<IActionResult> EditPost(int? postId)
        {
            if (postId == null)
            {
                return NotFound();
            }

            var post = await postService.GetPostByIdAsync(postId.Value);
            if (post == null)
            {
                return NotFound();
            }

            var categories = await categoryService.GetAllCategoryAsync();
            PostEditViewModel model = new PostEditViewModel { Post = post, Categories = categories };
            return View("Post/Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Manage/Post/Edit/{postId}")]
        public async Task<IActionResult> EditPost(int postId, [Bind("Title,Description,Content,Id,AuthorId,CategoryId,CategoryName,ImagePath")] PostDto post)
        {
            if (postId != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    post.Slug = RegexHelper.CreateSlug(post.Title);
                    await postService.UpdateAsync(post);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!postService.IsExist(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("PostManage", "Manage");
            }
            return View("Post/Edit", post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Manage/Post/Delete")]
        public async Task<IActionResult> DeletePost(int postId)
        {
            await postService.RemoveAsync(postId);
            return RedirectToAction("PostManage", "Manage");
        }

        #endregion

        #region Category Managing

        public IActionResult CreateCategory()
        {
            return View("Category/Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory([Bind("Name,Description,Id")] CategoryDto category)
        {
            if (ModelState.IsValid)
            {
                await categoryService.AddAsync(category);
                return RedirectToAction("CategoryManage", "Manage");
            }
            return View("Category/Create", category);
        }

        [Route("Category/Edit/{categoryId}")]
        public async Task<IActionResult> EditCategory(int? categoryId)
        {
            if (categoryId == null)
            {
                return NotFound();
            }

            var category = await categoryService.GetCategoryByIdAsync(categoryId.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View("Category/Edit", category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Category/Edit/{categoryId}")]
        public async Task<IActionResult> EditCategory(int categoryId, [Bind("Name,Description,Id")] CategoryDto category)
        {
            if (categoryId != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await categoryService.UpdateAsync(category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!categoryService.IsExist(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("CategoryManage", "Manage");
            }
            return View("Category/Edit", category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            await categoryService.RemoveAsync(categoryId);
            return RedirectToAction("CategoryManage", "Manage");
        }

        #endregion

        #region Comment Managing

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            await commentService.RemoveAsync(commentId);
            return RedirectToAction("CommentManage", "Manage");
        }

        #endregion
    }
}