using Employees_Manager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_Manager.Data.EFCore
{
    public class EmployeeRepository : ConcreteRepository<Employee>
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext _db) : base(_db)
        {
            this._db = _db;
        }


        public override async Task<Employee> Update(Employee employee)
        {

            var EmployeeTemp = await _db.Employee.Include(emp => emp.Vacations).SingleOrDefaultAsync(i => i.Id == employee.Id);

            EmployeeTemp.Name = employee.Name;
            EmployeeTemp.Email = employee.Email;
            EmployeeTemp.Dob = employee.Dob;
            EmployeeTemp.Vacations = employee.Vacations;


            await _db.SaveChangesAsync();

            return EmployeeTemp;
        }

    }
}
