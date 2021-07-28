using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers.SCRN0002
{
    public class SCRN0002Controller : Controller
    {
        [Route("entry")]
        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }
    }
}
