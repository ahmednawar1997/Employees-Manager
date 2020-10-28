using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Employees_Manager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Employees_Manager.Pages.Employees
{
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Employee Employee { set; get; }

        public CreateModel(ApplicationDbContext _db)
        {
            this._db = _db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Debug.WriteLine("Employee");

                Debug.WriteLine(Employee.Name);
                Debug.WriteLine(Employee.Vacations.Count());
                await _db.Employee.AddAsync(Employee);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                Debug.WriteLine("Employee");

                Debug.WriteLine(Employee.Name);
                Debug.WriteLine(Employee.Vacations.Count());
                Debug.WriteLine(Employee.Vacations.ElementAt(0).Vacation_Type);

                return Page();
            }
        }
    }
}
