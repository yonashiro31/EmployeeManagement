using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers.SCRN0001
{
    public class SCRN0001Controller : Controller
    {
        [Route("")]
        [Route("/employee/menu")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
