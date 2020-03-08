using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SEP.Framework.Seedwork.Identity;
using SEP.Framework.DAO.Context;

namespace SEP.Framework.DAO.Identity.UserStore
{
    public class DLRoleStore : RoleStore<Role, SepDbContext, int, UserRole, RoleClaim>
    {
        public DLRoleStore(SepDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
}
