using SEP.Framework.Seedwork.DTO;
using ReflectionIT.Mvc.Paging;
using System.Collections.Generic;
using SEP.Framework.DAO.DTO;
using SEP.Framework.MVC.ViewModels;

namespace BlogNetCore.MVC.Models
{
    public class PostDetailsViewModel : BaseViewModel
    {
        public PostDto Post { get; set; }
        public CommentDto Comment { get; set; }
    }

    public class PostIndexViewModel : BaseViewModel
    {
        public IPagingList<PostDto> PostList { get; set; }
    }

    public class PostCreateViewModel : BaseViewModel
    {
        public List<CategoryDto> Categories { get; set; }
        public PostDto Post { get; set; }
    }

    public class PostEditViewModel : BaseViewModel
    {
        public List<CategoryDto> Categories { get; set; }
        public PostDto Post { get; set; }
    }
}
