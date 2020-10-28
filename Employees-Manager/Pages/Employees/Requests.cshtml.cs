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
    public class RequestsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public RequestsModel(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        public IList<Request> Requests { get; set; }

        public async Task OnGet()
        {
            Requests = await _db.Request.Include(req => req.Employee).ToListAsync();
        }

        public async Task<IActionResult> OnPostAcceptRequest(int req_id)
        {
            var Request = await _db.Request.Include(req => req.Employee).SingleOrDefaultAsync(req =>req.Request_Id == req_id);

            var EmployeeTemp = await _db.Employee.Include(emp => emp.Vacations).SingleOrDefaultAsync(emp => emp.Id == Request.Employee.Id);

            foreach (Vacation vacation in EmployeeTemp.Vacations)
            {
                if(vacation.Vacation_Type == Request.Vacation_Type && vacation.Balance >= Request.Value)
                {
                    vacation.Balance -= Request.Value;
                    vacation.Used += Request.Value;
                    _db.Request.Remove(Request);
                    break;
                }
            }

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }

    }
}
