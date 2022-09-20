using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FractalzBackendScheduler.Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using FractalzBackendScheduler.Application.Domains.Entities;
using FractalzBackendScheduler.Infrastructure.Database.Contexts;
using FractalzBackendScheduler.Infrastructure.Database.Repositories;
using MediatR;

namespace FractalzBackendScheduler.Infrastructure.Database
{
    public static class ServiceCollection
    {
        /// <summary>
        /// DataBase
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddInfrastructureDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<SchedulerContext>(options => 
                options.UseMySql(configuration.GetConnectionString("DBConnection"), 
                new MySqlServerVersion(new Version(5, 6, 45))));
            services.AddTransient<IRepository<Notification>, NotificationRepository>();
            services.AddTransient<IRepository<Meeting>, MeetingRepository>();
            services.AddTransient<IRepository<Conference>, ConferenceRepository>();
        }
    }
}
