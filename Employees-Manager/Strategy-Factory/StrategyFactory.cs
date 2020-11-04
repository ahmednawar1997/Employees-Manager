using Employees_Manager.Startup_Strategies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_Manager.Strategy_Factory
{
    public class StrategyFactory
    {

        public static IStartupStrategy getStrategy(IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                return new DevelopmentStrategy();
            }
            else
            {
                return new ProductionStrategy();
            }

        }
    }
}
