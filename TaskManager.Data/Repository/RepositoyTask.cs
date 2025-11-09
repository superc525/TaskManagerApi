using TaskManager.Data.Interfaces;

namespace TaskManager.Data.Repository
{
    public class RepositoyTask: GenericRepository<Domain.Task> , IRepositoryTask
    {
        private readonly AppDbContext _context;
        public RepositoyTask(AppDbContext context): base (context) 
        {
            _context = context;
        }

        public void Update(Domain.Task entity)
        {
            var taskDB = _context.Tasks.FirstOrDefault(e => e.Id == entity.Id);
            if (taskDB != null)
            {
                taskDB.Description = entity.Description;
                taskDB.Status = entity.Status;
                taskDB.UpdateDate = entity.UpdateDate;
                _context.SaveChanges();
            }
        }
    }
}
