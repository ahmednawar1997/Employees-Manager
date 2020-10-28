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
    public class EditModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Employee Employee { set; get; }

        public EditModel(ApplicationDbContext _db)
        {
            this._db = _db;
        }
        public async Task OnGet(int id)
        {

            Employee = await _db.Employee.Include(emp => emp.Vacations).SingleOrDefaultAsync(i => i.Id == id);
            System.Diagnostics.Debug.WriteLine(Employee.Name);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                var EmployeeTemp = await _db.Employee.Include(emp => emp.Vacations).SingleOrDefaultAsync(i => i.Id == Employee.Id);

                EmployeeTemp.Name = Employee.Name;
                EmployeeTemp.Email = Employee.Email;
                EmployeeTemp.Dob = Employee.Dob;
                EmployeeTemp.Vacations = Employee.Vacations;


                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
             return Page();
      
        }
    }
}
