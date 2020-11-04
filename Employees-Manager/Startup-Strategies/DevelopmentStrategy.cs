using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_Manager.Startup_Strategies
{
    public class DevelopmentStrategy : ConcreteStartupStrategy
    {

        public override void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            base.Configure(app, env);
        }
    }
}
