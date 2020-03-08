using System.Linq;
using System.Threading.Tasks;
using SEP.Framework.Seedwork.Domain;

namespace SEP.Framework.Seedwork.Repository.Core
{
    public interface IRepository<TEntity, TId>
        where TEntity : BaseEntity<TId>
    {
        IQueryable<TEntity> Query();
        Task<TEntity> GetByIdAsync(TId id);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        Task<int> SaveChangesAsync();
    }


    public interface IRepository<TEntity> : IRepository<TEntity, int>
    where TEntity : BaseEntity<int>
    {

    }
}
