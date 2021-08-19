using EmployeeManagement.Helper;
using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers.SCRN0002
{
    public class SCRN0002Controller : Controller
    {
        /// <summary>社員管理登録画面のヘルパー</summary>
        /// <remarks>社員管理登録画面のヘルパー</remarks>
        private readonly IEV0002Helper _ev0002Helper = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>    
        /// <remarks>
        /// 社員管理システムメニュー画面のDI実施
        /// </remarks>
        /// <param name="ev0001Helper">社員メニュー画面のHelper</param>
        public SCRN0002Controller(IEV0002Helper ev0001Helper)
        {
            _ev0002Helper = ev0001Helper;
        }

        /// <summary>
        /// 画面表示時メソッド
        /// </summary>
        /// <returns></returns>
        [Route("employee/entry")]
        [HttpPost]
        public IActionResult Index()
        {
            var messageToHtml = _ev0002Helper.Init();
            messageToHtml.Gender = "男";
            return View(messageToHtml);
        }

        /// <summary>
        /// 登録時メソッド
        /// </summary>
        /// <returns></returns>
        [Route("employee/entry/excute")]
        [HttpPost]
        public IActionResult Excute(SCRN0002ViewModel sCRN0002ViewModel)
        {
            var messageToHtml = _ev0002Helper.Entry(sCRN0002ViewModel);        
            return View("Index",messageToHtml);
        }

        /// <summary>
        /// 戻るボタン押下時メソッド
        /// </summary>
        /// <returns></returns>
        [Route("employee/entry/Back")]
        [HttpGet]
        public IActionResult Back()
        {

            return View();
        }

    }
}