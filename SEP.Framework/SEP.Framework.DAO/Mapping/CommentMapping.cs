using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEP.Framework.Seedwork.Identity;
using SEP.Framework.DAO.Domain;

namespace SEP.Framework.DAO.Mapping
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Comments");

            entityTypeBuilder
                .HasOne<User>(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            entityTypeBuilder
                .HasOne<Post>(x => x.Post)
                .WithMany()
                .HasForeignKey(x => x.PostId);
        }
    }
}
