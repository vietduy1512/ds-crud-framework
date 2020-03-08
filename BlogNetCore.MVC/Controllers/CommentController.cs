using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SEP.Framework.AppService.ServiceContracts;
using SEP.Framework.DAO.DTO;
using SEP.Framework.MVC.Controllers;

namespace BlogNetCore.MVC.Controllers
{
    public class CommentController : BaseController
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService _commentService)
        {
            commentService = _commentService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment([Bind("Content,Id,UserId,PostId")] CommentDto comment)
        {
            if (ModelState.IsValid)
            {
                await commentService.AddAsync(comment);
                return ViewComponent("CommentSection", new { postId = comment.PostId });
            }
            return BadRequest();
        }
    }
}