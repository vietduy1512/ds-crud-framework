using AutoMapper;
using SEP.Framework.DAO.Domain;
using SEP.Framework.DAO.DTO;

namespace SEP.Framework.DAO.Mapping.Configuration
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<CategoryDto, Category>();

            CreateMap<Post, PostDto>()
                .ForMember(des => des.CategoryId, opt => opt.MapFrom(src => src.Category.Id))
                .ForMember(des => des.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ReverseMap();

            CreateMap<Comment, CommentDto>()
                .ForMember(des => des.PostCategory, opt => opt.MapFrom(src => src.Post.Category.Name))
                .ForMember(des => des.PostTitle, opt => opt.MapFrom(src => src.Post.Title))
                .ReverseMap();
        }
    }
}
