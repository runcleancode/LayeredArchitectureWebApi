using System.Security.Cryptography;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Presentation.ActionFilters;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracts;

namespace WebApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
                services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("sqlConnection")
                ));
        public static void ConfigureRepositoryManager(this IServiceCollection services) => services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerService, LoggerManager>();

        public static void ConfigureMapping(this IServiceCollection services) =>
        services.AddAutoMapper(typeof(Program));

        public static void ConfigureActionFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
            services.AddSingleton<LogFilterAttribute>();
            services.AddScoped<ValidateMediaTypeAttribute>();
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("X-Pagination"));
            });
        }

        public static void ConfigureDataShaper(this IServiceCollection services)
        {
            services.AddScoped<IDataShaper<BookDto>, DataShaper<BookDto>>();
        }

        public static void AddCustomMediaTypes(this IServiceCollection services)
        {
            services.Configure<MvcOptions>(config =>
            {
                // SystemTextJsonOutputFormatter YERİNE NewtonsoftJsonOutputFormatter YAZIYORUZ:
                var newtonsoftJsonOutputFormatter = config
                    .OutputFormatters
                    .OfType<NewtonsoftJsonOutputFormatter>()?
                    .FirstOrDefault();

                if (newtonsoftJsonOutputFormatter is not null)
                {
                    newtonsoftJsonOutputFormatter
                        .SupportedMediaTypes
                        .Add("application/vnd.company.hateoas+json");
                }

                var xmlOutputFormatter = config
                    .OutputFormatters
                    .OfType<XmlDataContractSerializerOutputFormatter>()?
                    .FirstOrDefault();

                if (xmlOutputFormatter is not null)
                {
                    xmlOutputFormatter.SupportedMediaTypes
                        .Add("application/vnd.company.hateoas+xml");
                }
            });
        }
        public static void ConfigureLinkBuilders(this IServiceCollection services) =>
            services.AddScoped<IBookLinks, BookLinks>();
    }
}