using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;


namespace SEP.Framework.Seedwork.Identity.Manager
{
    public class DLRoleManager : RoleManager<Role>
    {
        public DLRoleManager(
              IRoleStore<Role> store,
              IEnumerable<IRoleValidator<Role>> roleValidators,
              ILookupNormalizer keyNormalizer,
              IdentityErrorDescriber errors,
              ILogger<DLRoleManager> logger)
            : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}
