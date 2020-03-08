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
    public class CommentSectionViewComponent : BaseViewComponent
    {
        private readonly IRepository<Comment> commentRepository;

        public CommentSectionViewComponent(IRepository<Comment> _commentRepository)
        {
            commentRepository = _commentRepository;
        }


        public async Task<IViewComponentResult> InvokeAsync(int postId)
        {
            var comments = await commentRepository.Query()
                                                .ProjectTo<CommentDto>()
                                                .Where(x => x.PostId == postId)
                                                .OrderBy(x => x.CreatedDate)
                                                .ToListAsync();
            return View("CommentList", comments);
        }
    }
}
