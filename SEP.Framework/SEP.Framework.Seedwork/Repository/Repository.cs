using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using SEP.Framework.Seedwork.Domain;
using SEP.Framework.Seedwork.Repository.Core;

namespace SEP.Framework.Seedwork.Repository
{
    public class Repository<TEntity, TId, TContext> : IRepository<TEntity, TId>
        where TEntity : BaseEntity<TId>
        where TContext : DbContext
    {
        private readonly TContext DbContext;

        public Repository(TContext DbContext)
        {
            this.DbContext = DbContext;
        }

        private DbSet<TEntity> GetEntities()
        {
            return this.DbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Query()
        {
            return this.GetEntities().AsQueryable();
        }

        public async Task<TEntity> GetByIdAsync(TId id)
        {
            return await this.GetEntities().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public void Add(TEntity entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                this.DbContext.Attach(entity);
            }
            this.GetEntities().Add(entity);
        }

        public void Update(TEntity entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                this.DbContext.Attach(entity);
            }
            this.DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                this.DbContext.Attach(entity);
            }
            this.GetEntities().Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.DbContext.SaveChangesAsync();
        }
    }

    // Default repository
    public class Repository<TEntity> : Repository<TEntity, int, DbContext>, IRepository<TEntity>
        where TEntity : BaseEntity<int>
    {
        public Repository(DbContext DbContext) : base(DbContext)
        {
        }
    }
}
