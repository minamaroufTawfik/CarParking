using CarParking.Application.Business;
using CarParking.Application.Interfaces;
using CarParking.Core.Repositories;
using CarParking.Core.Repositories.Base;
using CarParking.Infrastructure.Data;
using CarParking.Infrastructure.Repositories;
using CarParking.Infrastructure.Repositories.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CarParking
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureCarParkingServices(services);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarParking", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarParking v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureCarParkingServices(IServiceCollection services)
        {
            ConfigureInfrastructureLayer(services);
            ConfigureApplicationLayer(services);
        }

        private void ConfigureInfrastructureLayer(IServiceCollection services)
        {
            ConfigureDatabases(services);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IParkingAccessCardRepository, ParkingAccessCardRepository>();
            services.AddScoped<ICarAccessHistoryRepository, CarAccessHistoryRepository>();
        }

        private void ConfigureApplicationLayer(IServiceCollection services)
        {
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<ICarManager, CarManager>();
            services.AddScoped<IParkingAccessCardManager, ParkingAccessCardManager>();
        }

        private void ConfigureDatabases(IServiceCollection services)
        {
            services.AddDbContext<CarParkingContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
