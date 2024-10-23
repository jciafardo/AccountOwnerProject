using Contract;
using Entities;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace AccountOwnerServer.Extensions
{
    /// <summary>
    /// Class <c>ServiceExtensions</c> Set up our extensions for config
    /// </summary>
    public static class ServiceExtensions

    {

        /// <summary>
        /// Configure CORS to allow any request from any orgin 
        /// </summary>
        /// <param name="services"> type of service collection</param>

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }


        /// <summary>
        /// Configure ISERVICE collection 
        /// </summary>
        /// <param name="services"> </param>
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        /// <summary>
        /// Configure Logger services 
        /// </summary>
        /// <param name="services"> type of servcive for our logger</param>
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        /// <summary>
        /// Configure sql
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["SqlConnection:ConnectionString"];
            Console.Write(connectionString);
            services.AddDbContext<RepositoryContext>(o => o.UseSqlServer(connectionString));
                
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
