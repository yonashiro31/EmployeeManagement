using EmployeeManagement.Judge;
using EmployeeManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Helper
{
    /// <summary>
    /// SCRN0002を補助するクラス
    /// </summary>
    /// <remarks>
    /// SCRN0002を補助するクラス
    /// </remarks>
    public class EV0002Helper : IEV0002Helper
    {
        /// <summary>
        /// 初期表示時メソッド
        /// </summary>
        /// <returns></returns>
        public SCRN0002ViewModel Init()
        {
            ErrorMessageModel errorMessageModel = new ErrorMessageModel();
            SCRN0002ViewModel SCRN0002ViewModelInstance = new SCRN0002ViewModel();
            return SCRN0002ViewModelInstance;
        }

        /// <summary>
        /// 新規登録時メソッド
        /// </summary>
        /// <returns>
        /// 入力値チェックメソッドを実行する
        /// </returns>
        public SCRN0002ViewModel Entry(SCRN0002ViewModel value)
        {
            (var checkResult, var errorMessageList) = EnteredValueCheck(value);
            if (!checkResult)
            {
                return new SCRN0002ViewModel()
                {
                    ErrorMessageList = errorMessageList,
                };
            }
            return new SCRN0002ViewModel();
        }

        private (bool, List<ErrorMessageModel>) EnteredValueCheck(SCRN0002ViewModel request)
        {
            ValueJudge judge = new ValueJudge();
            var checkResult = true;
            var errorMessageList = new List<ErrorMessageModel>();
            ErrorMessage errorMessage = new ErrorMessage();

            // 社員IDの入力値チェック
            if (!judge.Judge(request.EmployeeID))
            {
                checkResult = false;
                errorMessageList.Add(
                    new ErrorMessageModel()
                    {
                        MessageID = "COMMSG0001",
                        DisplayForMessage = ErrorMessage.IdMessage + ErrorMessage.NullMessage,
                    });
            }
            // 氏名の入力チェック
            if (!judge.Judge(request.EmployeeName))
            {
                checkResult = false;
                errorMessageList.Add(
                    new ErrorMessageModel()
                    {
                        MessageID = "",
                        DisplayForMessage = ErrorMessage.NameMessage　+　ErrorMessage.NullMessage,
                    });
            }
            // 
            if (!judge.Judge(request.BirthDay))
            {
                checkResult = false;
                errorMessageList.Add(
                    new ErrorMessageModel()
                    {
                        MessageID = "Err2",
                        DisplayForMessage = ErrorMessage.NullMessage,
                    });
            }
            return (checkResult, errorMessageList);
        }
    }
}
