namespace TaskManager.Data.Initializer
{
    using Microsoft.EntityFrameworkCore;

    public class DbInitializer : IdbInitializer
    {
        private readonly AppDbContext _context;

        public DbInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    //cuando se ejecuta por primera vez 
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
