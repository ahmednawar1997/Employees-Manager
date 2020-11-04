using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Employees_Manager.Models;
using Employees_Manager.Services;
using Employees_Manager.Services.ServicesImpl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Employees_Manager.Pages.Employees
{
    public class CreateModel : PageModel
    {


        [BindProperty]
        public Employee Employee { set; get; }

        private readonly IService<Employee> _empService;

        public CreateModel(EmployeeService _empService)
        {
            this._empService = _empService;
        }


        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _empService.Add(Employee);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
