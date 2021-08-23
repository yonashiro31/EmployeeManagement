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
             NullValueCheckSet(value);
            EntryJudgeListModel entryNullJudgeValues = new EntryJudgeListModel();
            // ToDoループ回数は変更
           // for (int i = 0; i < entryNullJudgeValues.NullValue.Length; i++)
            

                (var checkResult, var errorMessageList) = EnteredValueCheck(entryNullJudgeValues);


                if (!checkResult)
                 
            {
                return new SCRN0002ViewModel()
                {
                    ErrorMessageList = errorMessageList,
                };
            }
            return new SCRN0002ViewModel();
        }

        /// <summary>
        /// 未判定入力値セットメソッド
        /// </summary>
        /// <param name="request">入力値</param>
        /// <returns>未入力判定する値をlistに格納する</returns>
        public EntryJudgeListModel NullValueCheckSet(SCRN0002ViewModel request)
        {
            var judgeList = new List<EntryJudgeListModel>();
            EntryJudgeListModel entryJudgeListModel = new EntryJudgeListModel();
            List<EntryJudgeListModel> entryJudgeListModels = new List<EntryJudgeListModel>();

            entryJudgeListModel.NullCheckValue[0] = entryJudgeListModel.EmployeeID;
            entryJudgeListModel.NullCheckValue[1] = entryJudgeListModel.AffiliationCd;
            entryJudgeListModel.NullCheckValue[2] = entryJudgeListModel.PositionCd;
            entryJudgeListModel.NullCheckValue[3] = entryJudgeListModel.EmployeeName;
            entryJudgeListModel.NullCheckValue[4] = entryJudgeListModel.BaseSalary;

            return entryJudgeListModel;
        }

        /// <summary>
        /// 桁数判定入力値セットメソッド
        /// </summary>
        /// <param name="request">入力値</param>
        /// <returns>桁数判定する値をlistに格納する</returns>
        public List<EntryJudgeListModel> LengthValueCheckSet(SCRN0002ViewModel request)
        {
            List<EntryJudgeListModel> entryJudgeListModels = new List<EntryJudgeListModel>();
            var judgeList = new List<EntryJudgeListModel>();
            EntryJudgeListModel a = new EntryJudgeListModel();
            entryJudgeListModels.Add(
                  new EntryJudgeListModel()
                  {
                      EmployeeID = request.EmployeeID,
                      AffiliationCd = request.AffiliationCd,
                      PositionCd = request.PositionCd,
                      EmployeeName = request.EmployeeName,
                      BaseSalary = request.BaseSalary
                  });
            return judgeList;
        }

        //
        private (bool, List<ErrorMessageModel>) EnteredValueCheck(EntryJudgeListModel request)
        {
            var list = new EntryJudgeListModel();   
            ValueJudge judge = new ValueJudge();
            var checkResult = true;
            var errorMessageList = new List<ErrorMessageModel>();
            ErrorMessage errorMessage = new ErrorMessage();

            var judgeList = new List<EntryJudgeListModel>();
            // 社員IDの入力値チェック
            if (!judge.EnteredNullJudge(request.NullCheckValue[0]))
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
            if (!judge.EnteredNullJudge(request.NullCheckValue[3]))
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
           

            if (!judge.EnteredNullJudge(request.NullCheckValue[4]))
            {
                checkResult = false;
                errorMessageList.Add(
                    new ErrorMessageModel()
                    {
                        MessageID = "Err2",
                        DisplayForMessage = ErrorMessage.BaseSalaryMessage + ErrorMessage.NullMessage,
                    });
            }
            return (checkResult, errorMessageList);
        }
    }
}
