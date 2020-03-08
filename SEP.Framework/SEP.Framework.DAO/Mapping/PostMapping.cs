using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEP.Framework.Seedwork.Identity;
using SEP.Framework.DAO.Domain;

namespace SEP.Framework.DAO.Mapping
{
    public class PostMapping : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Posts");

            entityTypeBuilder
               .HasOne<User>(x => x.Author)
               .WithMany()
               .HasForeignKey(x => x.AuthorId);

            entityTypeBuilder
                .HasOne<Category>(x => x.Category)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            entityTypeBuilder
                .HasMany<Comment>(x => x.Comments)
                .WithOne(x => x.Post)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
