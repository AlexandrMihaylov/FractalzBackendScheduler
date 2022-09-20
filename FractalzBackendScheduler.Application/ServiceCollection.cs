using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FractalzBackendScheduler.Application.Abstractions;
using FractalzBackendScheduler.Application.Domains;
using FractalzBackendScheduler.Application.Handlers;

namespace FractalzBackendScheduler.Application
{
    public static class ServiceCollection
    {
        /// <summary>
        /// AddApplication
        /// </summary>
        /// <param name="services"></param>
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(ServiceCollection).GetTypeInfo().Assembly;
            services.AddMediatR(assembly);
        }
    }
}
