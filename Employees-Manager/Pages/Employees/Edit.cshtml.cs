using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employees_Manager.Models;
using Employees_Manager.Services;
using Employees_Manager.Services.ServicesImpl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Employees_Manager.Pages.Employees
{
    public class EditModel : PageModel
    {

        [BindProperty]
        public Employee Employee { set; get; }

        private readonly IService<Employee> _empService;

        public EditModel(EmployeeService _empService)
        {
            this._empService = _empService;
        }
        public async Task OnGet(int id)
        {

            Employee = await _empService.Get(id, emp => emp.Vacations);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                await _empService.Update(Employee);
                return RedirectToPage("Index");
            }
             return Page();
      
        }
    }
}
