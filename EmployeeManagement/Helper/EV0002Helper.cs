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
        /// <returns>
        /// 初期表示時に実行する処理
        /// </returns>
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
            // ToDo部署なども追加
            entryJudgeListModels.NullJudgeList.Add(request.EmployeeID);
            entryJudgeListModels.NullJudgeList.Add(request.AffiliationCd);
            entryJudgeListModels.NullJudgeList.Add(request.PositionCd);
            entryJudgeListModels.NullJudgeList.Add(request.EmployeeName);
            entryJudgeListModels.NullJudgeList.Add(request.BaseSalary);

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

        /// <summary>
        /// 入力判定時単項目チェックを呼び出すメソッド
        /// </summary>
        /// <param name="entryJudgeListModel">未入力チェック対象</param>
        /// <returns></returns>
        private List<ErrorMessageModel> EnteredValueCheck(EntryJudgeListModel entryJudgeListModel)
        {
            var list = new EntryJudgeListModel();
            ValueJudge valueJudge = new ValueJudge();
            var errorMessageList = new List<ErrorMessageModel>();
            ErrorMessages errorMessage = new ErrorMessages();
            var judgedValues = entryJudgeListModel.NullJudgeList.Select(s => valueJudge.EnteredNullJudge(s));
            ErrorMessages errorMessages = new ErrorMessages();
            int countNum = 0;
            foreach (var i in judgedValues)
            {
                // 社員IDの入力値チェック
                if (i == false)
                {
                    errorMessageList.Add(
                        new ErrorMessageModel()
                        {
                            MessageID = "COMMSG0001",
                            DisplayForMessage = errorMessages.itemNameMessageList[countNum] + errorMessages.instructionMessageList[0],
                        });
                }
                countNum++;
            }
            return errorMessageList;
        }

        /// <summary>
        /// 桁数判定単項目チェックを呼び出すメソッド
        /// </summary>
        /// <param name="entryJudgeListModel">未入力チェック対象</param>
        /// <returns></returns>
        private List<ErrorMessageModel> LengthValueCheck(EntryJudgeListModel entryJudgeListModel)
        {
            var list = new EntryJudgeListModel();
            ValueJudge valueJudge = new ValueJudge();
            var errorMessageList = new List<ErrorMessageModel>();
            ErrorMessages errorMessage = new ErrorMessages();
            var judgedValues = entryJudgeListModel.NullJudgeList.Select(s => valueJudge.EnteredNullJudge(s));
            ErrorMessages errorMessages = new ErrorMessages();
            int countNum = 0;
            foreach (var i in judgedValues)
            {
                // 社員IDの入力値チェック
                if (i == false)
                {
                    errorMessageList.Add(
                        new ErrorMessageModel()
                        {
                            MessageID = "COMMSG0001",
                            DisplayForMessage = errorMessages.itemNameMessageList[countNum] + errorMessages.instructionMessageList[0],
                        });
                }
                countNum++;
            }
            return errorMessageList;
        }
    }
}
