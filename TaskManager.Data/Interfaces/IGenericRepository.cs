namespace TaskManager.Data.Interfaces
{
    using System.Linq.Expressions;
    public interface IGenericRepository <T> where T : class
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null);
        Task<T?> Get(Expression<Func<T, bool>> filter = null, string includeProperties = "");
        Task Add(T entity);
        void Delete(T entity);
    }
}
