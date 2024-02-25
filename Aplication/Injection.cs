using Aplication.Students;
using Application.Professors;
using AutoMapper;
using Domain.Students;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication
{
    public static class Injection
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(StudentProfile));
            services.AddScoped<IStudentService, StudentService>();

            services.AddAutoMapper(typeof(ProfessorProfile));
            services.AddScoped<IProfessorService, ProfessorService>();

            return services;
        }
    }
}
