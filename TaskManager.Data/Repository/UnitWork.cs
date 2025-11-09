namespace TaskManager.Data.Repository
{
    using TaskManager.Data.Interfaces;
    public class UnitWork : IUnitWork
    {
        private readonly AppDbContext _context;

        public IRepositoryTask _Task { get; private set; }
        public UnitWork(AppDbContext context)
        {
            _context = context;
            _Task = new RepositoyTask(_context);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
