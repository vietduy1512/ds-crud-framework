using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace SEP.Framework.Seedwork.Identity.Manager
{
    public class DLUserManager : UserManager<User>
    {
        public DLUserManager(
             Microsoft.AspNetCore.Identity.IUserStore<User> store,
             IOptions<IdentityOptions> optionsAccessor,
             IPasswordHasher<User> passwordHasher,
             IEnumerable<IUserValidator<User>> userValidators,
             IEnumerable<IPasswordValidator<User>> passwordValidators,
             ILookupNormalizer keyNormalizer,
             IdentityErrorDescriber errors,
             IServiceProvider services,
             ILogger<DLUserManager> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }
    }
}
