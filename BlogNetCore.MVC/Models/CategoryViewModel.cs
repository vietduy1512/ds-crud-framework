using SEP.Framework.Seedwork.DTO;
using ReflectionIT.Mvc.Paging;
using SEP.Framework.DAO.DTO;
using SEP.Framework.MVC.ViewModels;

namespace BlogNetCore.MVC.Models
{
    public class PostListByCategoryViewModel : BaseViewModel
    {
        public IPagingList<PostDto> PostList { get; set; }
        public CategoryDto Category { get; set; }
    }
}
