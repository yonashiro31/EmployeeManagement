using EmployeeManagement.Helper.Interface;
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

        /// <summary>社員管理登録画面のヘルパー</summary>
        /// <remarks>社員管理登録画面のヘルパー</remarks>
        private readonly IEV0003Helper _ev0003Helper = null;
        /// <summary>
        /// SCRN0003Controllerコンストラクタ
        /// </summary>    
        /// <remarks>
        /// 社員管理登録画面のDI実施
        /// </remarks>
        /// <param name="ev0003Helper">社員登録画面のヘルパー</param>
        public SCRN0003Controller(IEV0003Helper ev0003Helper)
        {
            _ev0003Helper = ev0003Helper;
        }

        [Route("employee/updata")]
        [HttpPost]
        public IActionResult Index(string employeeId)
        {
            SCRN0001ViewModel test = new SCRN0001ViewModel
            {
                EmployeeID = employeeId
            };
            var viewValues = _ev0003Helper.Init(employeeId);
            return View();
        }
    }
}
