namespace TaskManager.Data.Interfaces
{
    public interface IUnitWork: IDisposable
    {
        IRepositoryTask _Task { get; }
        Task Save();
    }
}
