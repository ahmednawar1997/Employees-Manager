using System;
using System.Collections.Generic;
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
        public Employee Employee { set; get; }

        public CreateModel(ApplicationDbContext _db)
        {
            this._db = _db;
        }
        public void OnGet()
        {
        }
    }
}
