using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employees_Manager.Models;
using Employees_Manager.Services;
using Employees_Manager.Services.ServicesImpl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Employees_Manager.Pages.Employees
{
    public class RequestsModel : PageModel
    {
        private readonly IService<Employee> _empService;
        private readonly IService<Request> _reqService;
        public RequestsModel(EmployeeService _empService, RequestService _reqService)
        {
            this._empService = _empService;
            this._reqService = _reqService;
        }

        public IList<Request> Requests { get; set; }

        public async Task OnGet()
        {
            Requests = await _reqService.GetAll(req => req.Employee);
        }

        public async Task<IActionResult> OnPostAcceptRequest(int req_id)
        {
            var Request = await _reqService.Get(req_id, req => req.Employee);

            var EmployeeTemp = await _empService.Get(Request.Employee.Id, emp => emp.Vacations);

            foreach (Vacation vacation in EmployeeTemp.Vacations)
            {
                if(vacation.Vacation_Type == Request.Vacation_Type && vacation.Balance >= Request.Value)
                {
                    vacation.Balance -= Request.Value;
                    vacation.Used += Request.Value;
                    await _reqService.Delete(Request.Id);
                    break;
                }
            }

            return RedirectToPage("Index");
        }

    }
}
