using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SEP.Framework.Seedwork.Identity;
using SEP.Framework.DAO.Context;

namespace SEP.Framework.DAO.Identity.UserStore
{
    public class DLUserStore : UserStore<User, Role, SepDbContext, int, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>
    {
        public DLUserStore(SepDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
}
