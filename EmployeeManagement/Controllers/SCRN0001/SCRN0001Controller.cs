using EmployeeManagement.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers.SCRN0001
{
    /// <summary>
    ///画面制御を行うクラス
    /// </summary>
    ///<remarks>
    ///IEV0001Helperから必要な処理を受け取りViewに返す
    /// </remarks>
    public class SCRN0001Controller : Controller
    {
        /// <summary>
        ///画面制御
        /// </summary>
        ///<remarks>
        ///IEV0001Helperから必要な処理を受け取りViewに返す
        /// </remarks>   
        [Route("")]
        [Route("/employee/menu")]
        [HttpGet]
        public IActionResult Index()
        {
            EV0001Helper instanceEV0001Helper = new EV0001Helper();
            var MessageToHtml = instanceEV0001Helper.Init();
            return View(MessageToHtml);
        }

    }
}
