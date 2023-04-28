using Application.Activities;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace APIReactivities.Extensions;

public static class ApplicationServiceExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();
        
        services.AddDbContext<DataContext>(option =>
        {
            option.UseSqlServer(config.GetConnectionString("DefaultSqlConnection"));
        });
        
        services.AddCors(option =>
        {
            option.AddPolicy("CorsPolicy", policy =>
            {
                policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
            });
        });

        services.AddMediatR(option =>
        {
            option.RegisterServicesFromAssemblies(typeof(List.Handler).Assembly);
        });

        return services;
    }
}

