namespace TaskManager.Service.Services
{
    using AutoMapper;
    using TaskManager.Data.Interfaces;
    using TaskManager.Domain.Dtos;
    using TaskManager.Service.Services.Interfaces;
    public class TaskService : ITaskService
    {
        private readonly IUnitWork _unidadWork;
        private readonly IMapper _mapper;
        public TaskService(IUnitWork unidadWork, IMapper mapper)
        {
            _unidadWork = unidadWork;
            _mapper = mapper;
        }

        public async Task<DtoTask> AddTask(DtoTask modelDto)
        {
            try
            {
                Domain.Task task = new Domain.Task
                {
                    Title = modelDto.Title,
                    Description = modelDto.Description,
                    Status = (int)modelDto.Status,
                    CreationDate = DateTime.Now,
                    UpdateDate = null
                };
                await _unidadWork._Task.Add(task);
                await _unidadWork.Save();
                if (task.Id == 0)
                {
                    throw new Exception("No se pudo crear la tarea");
                }
                return _mapper.Map<DtoTask>(task);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DtoGetTask> GetTask(int Id)
        {
            try
            {
                var task = await _unidadWork._Task.Get(x => x.Id == Id, includeProperties: "TaskStatus");
                if (task == null)
                {
                    throw new Exception($"No se encontro la tarea con el Id: {Id}");
                }
                return _mapper.Map<DtoGetTask>(task);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<DtoGetTask>> GetTaskAll()
        {
            try
            {
                var list = await _unidadWork._Task.GetAll(includeProperties: "TaskStatus",
                    orderBy: e => e.OrderBy(e => e.Id));
                return _mapper.Map<IEnumerable<DtoGetTask>>(list);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task RemoverTask(int id)
        {
            var task = await _unidadWork._Task.Get(e => e.Id == id);
            if (task == null)
            {
                throw new TaskCanceledException("No se encontro la tarea con el Id: {Id}");
            }
            _unidadWork._Task.Delete(task);
            await _unidadWork.Save();
        }

        public async Task UpdatTask(DtoTask modelDto)
        {
            try
            {
                var taskDB = await _unidadWork._Task.Get(x => x.Id == modelDto.Id);
                if (taskDB == null)
                {
                    throw new TaskCanceledException("La tarea ingresada no existe");
                }
                taskDB.Title = modelDto.Title;
                taskDB.Description = modelDto.Description;
                taskDB.Status = (int)modelDto.Status;
                taskDB.UpdateDate = DateTime.Now;
                await _unidadWork.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
