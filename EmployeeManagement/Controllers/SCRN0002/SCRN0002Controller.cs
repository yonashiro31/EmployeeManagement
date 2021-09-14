using EmployeeManagement.Helper;
using EmployeeManagement.Session.Interface;
using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers.SCRN0002
{
    /// <summary>
    /// コントローラークラス
    /// </summary>
    /// <remarks>
    /// 登録画面のController
    /// </remarks>
    public class SCRN0002Controller : Controller
    {
        /// <summary>社員管理登録画面のヘルパー</summary>
        /// <remarks>社員管理登録画面のヘルパー</remarks>
        private readonly IEV0002Helper _ev0002Helper = null;
        /// <summary>
        /// SCRN0002Controllerコンストラクタ
        /// </summary>    
        /// <remarks>
        /// 社員管理登録画面のDI実施
        /// </remarks>
        /// <param name="ev0002Helper">社員登録画面のヘルパー</param>
        public SCRN0002Controller(IEV0002Helper ev0002Helper)
        {
            _ev0002Helper = ev0002Helper;
        }

        /// <summary>
        /// 画面表示時メソッド
        /// </summary>
        /// <returns>
        /// 画面表示に必要なデータを渡す
        /// </returns>
        [Route("employee/entry")]
        [HttpPost]
        public IActionResult Index()
        {
            var messageToHtml = _ev0002Helper.Init();
            return View(messageToHtml);
        }

        /// <summary>
        /// 登録時メソッド
        /// </summary>
        /// <returns>
        /// 登録時必要な情報をViewに渡す
        /// </returns>
        /// <param name="sCRN0002ViewModel">SCRN0002ViewModelのインスタンス</param>
        [Route("employee/entry/excute")]
        [HttpPost]
        public IActionResult Excute(SCRN0002ViewModel sCRN0002ViewModel)
        {
            var messageToHtml = _ev0002Helper.Entry(sCRN0002ViewModel);

            if(messageToHtml.ErrorMessageList.Count == 0)
            {
                return RedirectToAction("Index", "SCRN0004");
            }
            return View("Index", messageToHtml);
        }

        /// <summary>
        /// 戻るボタン押下時メソッド
        /// </summary>
        /// <returns>
        /// 戻るボタン押下時の必要処理
        /// </returns>
        [Route("employee/entry/Back")]
        [HttpGet]
        public IActionResult Back()
        {
            return RedirectToAction("Index", "SCRN0001");
        }
    }
}