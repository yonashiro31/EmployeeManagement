using NUnit.Framework;
using EmployeeManagement.Controllers.SCRN0001;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.ViewModel;
using EmployeeManagementWebUITest.ControllerTest.Mock;

namespace EmployeeManagementWebUITest.ControllerTest
{
    /// <summary>
    /// SCRN0001Controllerテストクラス
    /// </summary>
    /// <remarks>
    /// メニュー画面表示時の処理をテストを行う
    /// </remarks>
    [TestFixture]
    public class SCRN0001ControllerTest
    {
        /// <summary>
        /// テストメソッド
        /// </summary>
        /// <remarks>
        /// メニュー画面表示時、出力が空になっているか検証する
        /// </remarks>
        [Test]
        public void IndexTest()
        {
            var helperMockData = new SCRN0001HelperMock
            {
                ViewModel = new SCRN0001ViewModel()
                {
                    EmployeeID = string.Empty,
                    ErrorMessageList = new List<ErrorMessageModel>(),
                }
            };

            // テストメソッド呼び出し
            var testInstance = new SCRN0001Controller(helperMockData);
            var actResult = testInstance.Index();

            var actResultViewModel = (ViewResult)actResult;

            // SCRN0001ViewModelの検証
            Assert.IsAssignableFrom<SCRN0001ViewModel>(actResultViewModel.ViewData.Model);

            // ViewNameが空文字か検証
            Assert.AreEqual(null, actResultViewModel.ViewName);

            // 社員IDとメッセージがデフォルトの状態か検証
            var actResultModel = (SCRN0001ViewModel)actResultViewModel.ViewData.Model;
            Assert.AreEqual(string.Empty, actResultModel.EmployeeID);
            CollectionAssert.IsEmpty(actResultModel.ErrorMessageList);
        }
    }
}
