namespace TaskManager.Data.Interfaces
{
    public interface IRepositoryTask : IGenericRepository<Domain.Task>
    {
        void Update(Domain.Task entity);
    }
}
