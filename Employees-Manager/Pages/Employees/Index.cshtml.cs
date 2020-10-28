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

        [BindProperty]
        public Request Request { get; set; }

        public async Task OnGet()
        {
            Employees = await _db.Employee.Include(emp => emp.Vacations).ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var employee = await _db.Employee.FindAsync(id);
            _db.Employee.Remove(employee);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }

        public async Task<JsonResult> OnGetEmployeeAsync(int id)
        {
            var employee = await _db.Employee.Include(emp => emp.Vacations).SingleOrDefaultAsync(i => i.Id == id);
            return new JsonResult(employee);
        }


        public async Task<IActionResult> OnPostRequestAsync()
        {
            //Don't know if this is the right way or should I just add Employee_Id in Request instead of Employee
            var EmployeeTemp = await _db.Employee.FindAsync(Request.Employee.Id);
            Request.Employee = EmployeeTemp;
            await _db.Request.AddAsync(Request);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");             
        }
    }
}
