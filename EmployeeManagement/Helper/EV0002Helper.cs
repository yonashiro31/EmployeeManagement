using EmployeeManagement.Judge;
using EmployeeManagement.ViewModel;
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


            // ToDoループ回数は変更
            //


            EntryJudgeListModel entryJudgeListModel = NullValueCheckSet(value);
            

            var errorMessageList = EnteredValueCheck(entryJudgeListModel);



            return new SCRN0002ViewModel()
            {
                ErrorMessageList = errorMessageList,
            };
        }

        /// <summary>
        /// 未判定入力値セットメソッド
        /// </summary>
        /// <param name="request">入力値</param>
        /// <returns>未入力判定する値をlistに格納する</returns>
        public EntryJudgeListModel NullValueCheckSet(SCRN0002ViewModel request)
        {
            EntryJudgeListModel entryJudgeListModels = new EntryJudgeListModel();

           entryJudgeListModels.JudgeList.Add(request.EmployeeID);
            entryJudgeListModels.JudgeList.Add(request.AffiliationCd);
           entryJudgeListModels.JudgeList.Add(request.PositionCd);
           entryJudgeListModels.JudgeList.Add(request.EmployeeName);
           entryJudgeListModels.JudgeList.Add(request.BaseSalary);

            return entryJudgeListModels;
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
        private List<ErrorMessageModel>  EnteredValueCheck(EntryJudgeListModel s)
        {
            var list = new EntryJudgeListModel();   
            ValueJudge judge = new ValueJudge();
            var errorMessageList = new List<ErrorMessageModel>();
            ErrorMessage errorMessage = new ErrorMessage();
            var judgedValues = s.JudgeList.Select(s => judge.EnteredNullJudge(s));

            foreach (var i in judgedValues)
            {
                // 社員IDの入力値チェック
                if (i == false)
                {
                    errorMessageList.Add(
                        new ErrorMessageModel()
                        {
                            MessageID = "COMMSG0001",
                            DisplayForMessage = ErrorMessage.IdMessage + ErrorMessage.NullMessage,
                        });
                }
            }
            return errorMessageList;
        }
    }
}
