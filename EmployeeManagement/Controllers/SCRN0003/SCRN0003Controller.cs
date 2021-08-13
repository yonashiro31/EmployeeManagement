using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers.SCRN0003
{
    public class SCRN0003Controller : Controller
    {
        [Route("employee/updata")]
        [HttpPost]
        public IActionResult Index(string EmployeeID)
        {
            SCRN0001ViewModel test = new SCRN0001ViewModel();
            test.EmployeeID = EmployeeID;

            return View(test);
        }
    }
}
