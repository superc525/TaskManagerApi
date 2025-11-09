namespace TaskManager.Data
{
    using Microsoft.EntityFrameworkCore;
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Domain.Task> Tasks { get; set; }
        public DbSet<Domain.TaskStatus> TaskStatuses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Domain.TaskStatus>().HasData(
                new Domain.TaskStatus { Id = 1, Status = "Pending" },
                new Domain.TaskStatus { Id = 2, Status = "InProgress" },
                new Domain.TaskStatus { Id = 3, Status = "Completed" });
            modelBuilder.Entity<Domain.Task>()
                .HasOne(t => t.TaskStatus)
                .WithMany(s => s.Tasks)
                .HasForeignKey(t => t.Status);
        }
    }
}
