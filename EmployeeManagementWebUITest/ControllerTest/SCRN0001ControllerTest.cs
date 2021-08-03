using System;
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
        /// 初期表示テストクラス
        /// </summary>
        /// <remarks>
        /// メニュー画面表示時の処理をテストを行う
        /// </remarks>
        [Test]
        public void SCRN0001Test()
        {
            var viewMock = new SCRN0001Mock
            {
                SCRN0001ViewModelMock = new SCRN0001ViewModel()
                {
                    EmployeeID = string.Empty,
                    ErrorMessageList = new List<ErrorMessageModel>(),
                }
            };

            // テストメソッド呼び出し
            var testInstance = new SCRN0001Controller(viewMock);
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
