using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employees_Manager.Data;
using Employees_Manager.Models;
using Employees_Manager.Services;
using Employees_Manager.Services.ServicesImpl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Employees_Manager.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly IService<Employee> _empService;
        private readonly IService<Request> _reqService;

        public IndexModel(EmployeeService _empService, RequestService _reqService)
        {
            this._empService = _empService;
            this._reqService = _reqService;
        }

        public IList<Employee> Employees{ get; set; }

        [BindProperty]
        public Request Request { get; set; }

        public async Task OnGet()
        {
            Employees = await _empService.GetAll(emp => emp.Vacations);
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            Employee emp = await _empService.Delete(id);

            return RedirectToPage("Index");
        }

        public async Task<JsonResult> OnGetEmployeeAsync(int id)
        {
            var employee = await _empService.Get(id, emp => emp.Vacations);
            return new JsonResult(employee);
        }


        public async Task<IActionResult> OnPostRequestAsync()
        {
            //Don't know if this is the right way or should I just add Employee_Id in Request instead of Employee

            var EmployeeTemp = await _empService.Get(Request.Employee.Id, emp => emp.Vacations);
            Request.Employee = EmployeeTemp;
            await _reqService.Add(Request);
            return RedirectToPage("Index");             
        }
    }
}
