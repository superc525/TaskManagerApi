namespace TaskManager.Extensions
{
    using Microsoft.EntityFrameworkCore;
    using TaskManager.Data;
    using TaskManager.Data.Interfaces;
    using TaskManager.Data.Repository;
    using TaskManager.Service.Services;
    using TaskManager.Service.Services.Interfaces;
    using TaskManager.Utilities;
    public static class AplicationServiceExtension
    {
        public static IServiceCollection AplicationService(this IServiceCollection services, IConfiguration config)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            //Cadena de conexión
            var connectioString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectioString));
            //UnitOfWork
            services.AddScoped<IUnitWork, UnitWork>();
            //Automapper
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<ITaskService, TaskService>();

            return services;
        }
    }
}
