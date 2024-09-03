using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Service.Services.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Service.Helpers;
using Service.DTOs.Account;

namespace Service
{
    public static  class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableDataAnnotationsValidation = true;
            });

            services.AddScoped<IValidator<RegisterDto>, RegisterDtoValidator>();


            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();
            //services.AddScoped<IAuthorService, AuthorService>();

            services.AddScoped<IAccountService, AccountService>();

            return services;
        }
    }
}
