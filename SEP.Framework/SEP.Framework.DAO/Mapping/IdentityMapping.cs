using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEP.Framework.Seedwork.Identity;

namespace SEP.Framework.DAO.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Users");
        }
    }

    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Roles");
        }
    }

    public class UserClaimMapping : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("UserClaims");
        }
    }

    public class RoleClaimMapping : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("RoleClaims");
        }
    }

    public class UserLoginMapping : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("UserLogins");
        }
    }

    public class UserRoleMapping : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("UserRoles");
        }
    }

    public class UserTokenMapping : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("UserTokens");
        }
    }
}
