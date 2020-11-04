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
    public class IndexModel : PageModel
    {
        private readonly IRepository<Employee> _empRepository;
        private readonly IRepository<Request> _reqRepository;



        public IndexModel(EmployeeRepository _empRepository, RequestRepository _reqRepository)
        {
            this._empRepository = _empRepository;
            this._reqRepository = _reqRepository;
        }

        public IList<Employee> Employees{ get; set; }

        [BindProperty]
        public Request Request { get; set; }

        public async Task OnGet()
        {
            Employees = await _empRepository.GetAll(emp => emp.Vacations);
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            Employee emp = await _empRepository.Delete(id);

            return RedirectToPage("Index");
        }

        public async Task<JsonResult> OnGetEmployeeAsync(int id)
        {
            var employee = await _empRepository.Get(id, emp => emp.Vacations);
            return new JsonResult(employee);
        }


        public async Task<IActionResult> OnPostRequestAsync()
        {
            //Don't know if this is the right way or should I just add Employee_Id in Request instead of Employee

            var EmployeeTemp = await _empRepository.Get(Request.Employee.Id, emp => emp.Vacations);
            Request.Employee = EmployeeTemp;
            await _reqRepository.Add(Request);
            return RedirectToPage("Index");             
        }
    }
}
