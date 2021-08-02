using EmployeeManagement.Helper;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers.SCRN0001
{
    /// <summary>
    /// 社員管理メニュー画面制御を行うクラス
    /// </summary>
    ///<remarks>
    /// 社員管理IEV0001Helperから必要な処理を受け取りViewに返す
    /// </remarks>
    public class SCRN0001Controller : Controller
    {
        ///<summary>社員管理メニュー画面のヘルパー</summary>
        ///<remarks>社員管理メニュー画面のヘルパー</remarks>
        private readonly IEV0001Helper _ev0001Helper = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>    
        /// <remarks>
        /// 社員メ管理ニュー画面のDI実施
        /// </remarks>
        /// <param name="ev0001Helper">社員メニュー画面のHelper</param>
        public SCRN0001Controller(IEV0001Helper ev0001Helper)
        {
            _ev0001Helper = ev0001Helper;
        }

        /// <summary>
        /// 社員管理メニュー画面制御
        /// </summary>
        /// <remarks>
        /// IEV0001Helperから必要な処理を受け取りViewに返す
        /// </remarks>   
        [Route("")]
        [Route("/employee/menu")]
        [HttpGet]
        public IActionResult Index()
        {
            var messageToHtml = _ev0001Helper.Init();
            return View(messageToHtml);
        }
    }
}
