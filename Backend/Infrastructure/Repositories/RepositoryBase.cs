using Domain.RepositoryInterfaces;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext;
        public RepositoryBase(RepositoryContext repositoryContext) => this.RepositoryContext = repositoryContext;
        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        public void Delete(T entity) => RepositoryContext?.Set<T>().Remove(entity);
        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? RepositoryContext.Set<T>().AsNoTracking()
            : RepositoryContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool trackChanges) =>
        !trackChanges ? RepositoryContext.Set<T>().Where(condition).AsNoTracking() : RepositoryContext.Set<T>().Where(condition);
    }
    
}
