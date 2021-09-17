using EmployeeManagement.Helper;
using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
        /// <remarks>
        /// 画面表示に必要なデータを渡す
        /// </remarks>
        /// <returns>初期表示に必要なデータを返却する</returns>
        [Route("employee/entry")]
        [HttpPost]
        public IActionResult Index()
        {
            var indexViewValues = _ev0002Helper.Init();
            return View(indexViewValues);
        }

        /// <summary>
        /// 登録時メソッド
        /// </summary>
        /// <remarks>
        /// 登録時必要な情報をViewに渡す
        /// </remarks>
        /// <param name="sCRN0002ViewModel">SCRN0002ViewModelのインスタンス</param>
        /// <returns>登録情報を返却する</returns>

        [Route("employee/entry/excute")]
        [HttpPost]
        public IActionResult Excute(SCRN0002ViewModel sCRN0002ViewModel)
        {
            var entryValues = _ev0002Helper.Entry(sCRN0002ViewModel);

            if(!entryValues.ErrorMessageList.Any())
            {
                return RedirectToAction("Index", "SCRN0004");
            }
            return View("Index", entryValues);
        }

        /// <summary>
        /// 戻るボタン押下時メソッド
        /// </remarks>
        /// <returns>
        /// 戻るボタン押下時の必要処理
        /// </remarks>
        /// <returns>初期表示画面に処理を返却する</returns>
        [Route("employee/entry/back")]
        [HttpGet]
        public IActionResult Back()
        {
            return RedirectToAction("Index", "SCRN0001");
        }
    }
}