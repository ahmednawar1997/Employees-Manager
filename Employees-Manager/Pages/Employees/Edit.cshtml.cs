using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employees_Manager.Data;
using Employees_Manager.Data.EFCore;
using Employees_Manager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Employees_Manager.Pages.Employees
{
    public class EditModel : PageModel
    {

        [BindProperty]
        public Employee Employee { set; get; }

        private readonly IRepository<Employee> _empRepository;

        public EditModel(EmployeeRepository _empRepository)
        {
            this._empRepository = _empRepository;
        }
        public async Task OnGet(int id)
        {

            Employee = await _empRepository.Get(id, emp => emp.Vacations);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                await _empRepository.Update(Employee);
                return RedirectToPage("Index");
            }
             return Page();
      
        }
    }
}
