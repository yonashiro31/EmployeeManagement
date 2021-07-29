using EmployeeManagement.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers.SCRN0001
{
    public class SCRN0001Controller : Controller
    {

        //社員更新画面（SCRN0003）表示時、エラーが設定されていた場合は受け取る
       

        /// <summary>
        ///画面制御
        /// </summary>
    ///<remarks>
    ///画面制御を行う
    /// </remarks>
    [Route("")]
    [Route("/employee/menu")]
    [HttpGet]
    public IActionResult Index()
        {
            
            EV0001Helper instanceEV0001Helper = new EV0001Helper();
            instanceEV0001Helper.Init();
            return View();
        }

    }
}
