using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEP.Framework.DAO.Domain;

namespace SEP.Framework.DAO.Mapping
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Categories");
            entityTypeBuilder
                .HasMany<Post>(x => x.Posts);
        }
    }
}
