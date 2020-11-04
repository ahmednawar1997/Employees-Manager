using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_Manager.Startup_Strategies
{
    public interface IStartupStrategy
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env);


    }
}
