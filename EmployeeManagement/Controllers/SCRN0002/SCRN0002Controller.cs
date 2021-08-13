using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers.SCRN0002
{
    public class SCRN0002Controller : Controller
    {
        [Route("employee/entry")]
        [HttpPost]
        public IActionResult Index()
        {
            SCRN0002ViewModel test = new SCRN0002ViewModel();
                 
            return View(test);
        }
    }
}
