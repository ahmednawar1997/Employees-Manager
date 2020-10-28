using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employees_Manager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Employees_Manager.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;


        public IndexModel(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        public IList<Employee> Employees{ get; set; }
        public async Task OnGet()
        {

            Employees = await _db.Employee.Include(emp => emp.Vacations).ToListAsync();
            //Employees = await _db.Employee.ToListAsync();

            System.Diagnostics.Debug.WriteLine(Employees.Count());
            System.Diagnostics.Debug.WriteLine(Employees.ElementAt(0).Vacations.Count());

        }
    }
}
