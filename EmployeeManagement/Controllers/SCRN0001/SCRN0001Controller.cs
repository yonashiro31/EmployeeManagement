using EmployeeManagement.Helper;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers.SCRN0001
{
    /// <summary>
    ///メニュー画面制御を行うクラス
    /// </summary>
    ///<remarks>
    ///IEV0001Helperから必要な処理を受け取りViewに返す
    /// </remarks>
    public class SCRN0001Controller : Controller
    {
        ///<symmarry>変数宣言と初期化</symmarry>
        ///<remarks>変数宣言と初期化</remarks>
        private readonly IEV0001Helper _ev0001Helper = null;

        ///<symmarry>
        /// DI実施
        /// </symmarry>
        ///<remarks>
        /// DI実施
        /// </remarks>
        public SCRN0001Controller(IEV0001Helper ev0001Helper)
        {
            _ev0001Helper = ev0001Helper;
        }

        /// <summary>
        ///メニュー画面制御
        /// </summary>
        /// <remarks>
        ///IEV0001Helperから必要な処理を受け取りViewに返す
        /// </remarks>   
        [Route("")]
        [Route("/employee/menu")]
        [HttpGet]
        public IActionResult Index()
        {
            var MessageToHtml = _ev0001Helper.Init();
            return View(MessageToHtml);
        }

    }
}
