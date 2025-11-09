
namespace TaskManager.Service.Services.Interfaces
{
    using TaskManager.Domain.Dtos;

    public interface ITaskService
    {
        Task<IEnumerable<DtoGetTask>> GetTaskAll();
        Task<DtoGetTask> GetTask(int Id);
        Task<DtoTask> AddTask(DtoTask modelDto);
        Task UpdatTask(DtoTask modelDto);
        Task RemoverTask(int id);
    }
}
