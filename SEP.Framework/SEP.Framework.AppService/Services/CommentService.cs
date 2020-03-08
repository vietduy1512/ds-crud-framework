using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP.Framework.Seedwork.Repository.Core;
using SEP.Framework.DAO.Domain;
using SEP.Framework.DAO.DTO;
using SEP.Framework.AppService.ServiceContracts;

namespace SEP.Framework.AppService.Services
{
    public class CommnentService : ICommentService
    {
        private readonly IRepository<Comment> commentRepository;
        private readonly IMapper mapper;

        public CommnentService(IRepository<Comment> _commentRepository, IMapper _mapper)
        {
            commentRepository = _commentRepository;
            mapper = _mapper;
        }

        public async Task<CommentDto> GetPostByIdAsync(int id)
        {
            return await commentRepository.Query()
                            .ProjectTo<CommentDto>()
                            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<CommentDto>> GetAllCommentAsync()
        {
            return await commentRepository.Query()
                                        .ProjectTo<CommentDto>()
                                        .ToListAsync();
        }

        public async Task<int> AddAsync(CommentDto dto)
        {
            var entity = new Comment
            {
                Id = dto.Id,
                Content = dto.Content,
                UserId = dto.UserId,
                PostId = dto.PostId
            };
            commentRepository.Add(entity);
            return await commentRepository.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(int id)
        {
            var comment = await commentRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            commentRepository.Remove(comment);
            return await commentRepository.SaveChangesAsync();
        }
    }
}
