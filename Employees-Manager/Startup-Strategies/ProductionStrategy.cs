using Employees_Manager.Data.EFCore;
using Employees_Manager.Models;
using Employees_Manager.Services.ServicesImpl;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_Manager.Startup_Strategies
{
    public class ProductionStrategy : ConcreteStartupStrategy
    {

        public override void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();

            base.Configure(app, env);

        }
    }
}
