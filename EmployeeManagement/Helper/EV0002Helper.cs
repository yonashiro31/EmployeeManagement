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
        public SCRN0002ViewModel Entry(SCRN0002ViewModel sCRN0002ViewModel)
        {
            List<NullJudgeListModel> nullJudegeListModel = NullValueCheckSet(sCRN0002ViewModel);
            List<LengthJudgeListModel> lengthJudgeListModel = LengthValueCheckSet(sCRN0002ViewModel);
            // メソッドの戻り値であるエラーメッセージリストを結合する
            var errorMessageList = EnteredValueNullCheck(nullJudegeListModel).Concat(EnteredValueLengthCheck(lengthJudgeListModel)).ToList();

            return new SCRN0002ViewModel()
            {
                ErrorMessageList = errorMessageList
            };
        }

        /// <summary>
        /// 未判定入力値セットメソッド
        /// </summary>
        /// <param name="request">入力値</param>
        /// <returns>未入力判定する値をlistに格納する</returns>
        public List<NullJudgeListModel> NullValueCheckSet(SCRN0002ViewModel request)
        {
            // ToDo部署なども追加
            var test = new List<NullJudgeListModel>
            {
            new NullJudgeListModel(request.EmployeeID),
            new NullJudgeListModel(request.AffiliationCd),
            new NullJudgeListModel(request.PositionCd),
            new NullJudgeListModel(request.EmployeeName),
           new NullJudgeListModel(request.BaseSalary)
        };

            return test;
        }

        public List<LengthJudgeListModel> LengthValueCheckSet(SCRN0002ViewModel request)
        {
            // ToDo部署なども追加
            var test = new List<LengthJudgeListModel>
            {
            new LengthJudgeListModel(request.EmployeeID,8),
            new LengthJudgeListModel(request.AffiliationCd,8),
            new LengthJudgeListModel(request.PositionCd,8),
            new LengthJudgeListModel(request.EmployeeName,8),
            new LengthJudgeListModel(request.BaseSalary,8)
        };

            return test;
        }

        /// <summary>
        /// 入力判定時単項目チェックを呼び出すメソッド
        /// </summary>
        /// <param name="entryJudgeListModel">未入力チェック対象</param>
        /// <returns></returns>
        private List<ErrorMessageModel> EnteredValueNullCheck(List<NullJudgeListModel> entryJudgeListModel)
        {
            ValueJudge valueJudge = new ValueJudge();
            var errorMessageList = new List<ErrorMessageModel>();
            var judgeResult = entryJudgeListModel.Select(item => valueJudge.EnteredNullJudge(item.EmployeeDate));
            ErrorMessages errorMessages = new ErrorMessages();
            int countNum = 0;
            foreach (var i in judgeResult)
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
        /// <param name="checkTargetList">未入力チェック対象</param>
        /// <returns></returns>
        private List<ErrorMessageModel> EnteredValueLengthCheck(List<LengthJudgeListModel> checkTargetList)
        {
            ValueJudge valueJudge = new ValueJudge();
            var errorMessageList = new List<ErrorMessageModel>();
            ErrorMessages errorMessage = new ErrorMessages();

            var judgeResult = checkTargetList.Select(item => valueJudge.EnteredValueLengthJudge(item.EmployeeDate, item.Judgedigit));
            ErrorMessages errorMessages = new ErrorMessages();
            int countNum = 0;
            foreach (var i in judgeResult)
            {
                // 社員IDの入力値チェック
                if (i == false)
                {
                    errorMessageList.Add(
                        new ErrorMessageModel()
                        {
                            MessageID = "COMMSG0001",
                            DisplayForMessage = errorMessages.itemNameMessageList[countNum] + errorMessages.instructionMessageList[1],
                        });
                }
                countNum++;
            }
            return errorMessageList;
        }
    }
}
