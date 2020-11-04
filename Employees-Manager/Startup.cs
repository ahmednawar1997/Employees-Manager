using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employees_Manager.Data.EFCore;
using Employees_Manager.Models;
using Employees_Manager.Services.ServicesImpl;
using Employees_Manager.Startup_Strategies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Employees_Manager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IStartupStrategy startupStrategy{ get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddScoped<EmployeeRepository>();
            services.AddScoped<RequestRepository>(); 
            services.AddScoped<RequestService>();
            services.AddScoped<EmployeeService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                new DevelopmentStrategy().Configure(app, env);

            }
            else
            {
                new ProductionStrategy().Configure(app, env);
            }

           
        }
    }
}
