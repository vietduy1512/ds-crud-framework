using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP.Framework.Seedwork.Repository.Core;
using SEP.Framework.DAO.Domain;
using SEP.Framework.DAO.DTO;
using SEP.Framework.AppService.ServiceContracts;

namespace SEP.Framework.AppService.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> postRepository;
        private readonly IRepository<Category> categoryRepository;
        private readonly IMapper mapper;

        public PostService(IRepository<Post> _postRepository, IRepository<Category> _categoryRepository, IMapper _mapper)
        {
            postRepository = _postRepository;
            categoryRepository = _categoryRepository;
            mapper = _mapper;
        }

        public async Task<PostDto> GetPostByIdAsync(int id)
        {
            return await postRepository.Query()
                            .ProjectTo<PostDto>()
                            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PostDto>> GetAllPostAsync()
        {
            return await postRepository.Query()
                                    .ProjectTo<PostDto>()
                                    .ToListAsync();
        }

        public async Task<List<PostDto>> GetAllPostByCategoryId(int categoryId)
        {
            return await postRepository.Query()
                                    .Where(x => x.CategoryId == categoryId)
                                    .OrderByDescending(x => x.CreatedDate)
                                    .ProjectTo<PostDto>()
                                    .ToListAsync();
        }

        public IOrderedQueryable<PostDto> GetAllPostByCategoryIdDescendingQuery(int categoryId)
        {
            return postRepository.Query()
                            .Where(x => x.CategoryId == categoryId)
                            .ProjectTo<PostDto>()
                            .OrderByDescending(x => x.CreatedDate);
        }

        public IOrderedQueryable<PostDto> GetAllPostDescendingQuery()
        {
            return postRepository.Query()
                            .ProjectTo<PostDto>()
                            .OrderByDescending(x => x.CreatedDate);
        }

        public bool IsExist(int id)
        {
            return postRepository.Query().Any(e => e.Id == id);
        }

        public async Task<int> AddAsync(PostDto dto)
        {
            postRepository.Add(mapper.Map<Post>(dto));
            return await postRepository.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(PostDto dto)
        {
            postRepository.Update(mapper.Map<Post>(dto));
            return await postRepository.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(int id)
        {
            var post = await postRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            postRepository.Remove(post);
            return await postRepository.SaveChangesAsync();
        }
    }
}
