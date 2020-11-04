using Employees_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_Manager.Data.EFCore
{
    public class EmployeeRepository : ConcreteRepository<Employee>
    {

        public EmployeeRepository(ApplicationDbContext _db) : base(_db)
        {

        }
    }
}
