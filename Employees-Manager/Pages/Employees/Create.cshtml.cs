using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Employees_Manager.Data;
using Employees_Manager.Data.EFCore;
using Employees_Manager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Employees_Manager.Pages.Employees
{
    public class CreateModel : PageModel
    {


        [BindProperty]
        public Employee Employee { set; get; }

        private readonly IRepository<Employee> _empRepository;

        public CreateModel(EmployeeRepository _empRepository)
        {
            this._empRepository = _empRepository;
        }


        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _empRepository.Add(Employee);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
