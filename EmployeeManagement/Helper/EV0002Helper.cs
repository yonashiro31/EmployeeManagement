using EmployeeManagement.Constant;
using EmployeeManagement.Constants;
using EmployeeManagement.Judge;
using EmployeeManagement.Logic.Interface;
using EmployeeManagement.LogicDTO;
using EmployeeManagement.Session;
using EmployeeManagement.Session.Interface;
using EmployeeManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

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
        private readonly IEV8001Logic _ev8001Logic = null;
        private readonly IEV8002Logic _ev8002Logic = null;
        private readonly IEV8003Logic _ev8003Logic = null;
        /// <summary>
        /// インターフェースの用意
        /// </summary>
        /// <param name="ev8001Logic">社員情報取得ヘルパー</param>
        /// <param name="ev8002Logic">部署取得ヘルパー</param>
        /// <param name="ev8003Logic">役職取得ヘルパー</param>
        public EV0002Helper(IEV8001Logic ev8001Logic, IEV8002Logic ev8002Logic, IEV8003Logic ev8003Logic)
        {
            _ev8001Logic = ev8001Logic;
            _ev8002Logic = ev8002Logic;
            _ev8003Logic = ev8003Logic;
        }

        /// <summary>
        /// 初期表示時メソッド
        /// </summary>
        /// <returns>
        /// 初期表示時に実行する処理
        /// </returns>
        public SCRN0002ViewModel Init()
        {
            DisplayDinoteErrMessage errorMessageModel = new DisplayDinoteErrMessage();
            SCRN0002ViewModel sCRN0002ViewModel = new SCRN0002ViewModel();
            var AffiliationValues = _ev8002Logic.FindAll();

            sCRN0002ViewModel.AffiliationList = AffiliationValues.Select(item => new AffiliationInfo
            {
                AffiliationCd = item.AffiliationCd,
                AffiliationNm = item.ManagementNm,
            }).ToList();

            var PositionValues = _ev8003Logic.FindAll();
            sCRN0002ViewModel.PositionList = PositionValues.Select(item => new PositionInfo
            {
                PositionCd = item.PositionCd,
                PositionNm = item.PositionNm,
            }).ToList();
            sCRN0002ViewModel.Gender = 1;
            return sCRN0002ViewModel;
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

            var AffiliationValues = _ev8002Logic.FindAll();

            sCRN0002ViewModel.AffiliationList = AffiliationValues.Select(item => new AffiliationInfo
            {
                AffiliationCd = item.AffiliationCd,
                AffiliationNm = item.ManagementNm,
            }).ToList();

            var PositionValues = _ev8003Logic.FindAll();
            sCRN0002ViewModel.PositionList = PositionValues.Select(item => new PositionInfo
            {
                PositionCd = item.PositionCd,
                PositionNm = item.PositionNm,
            }).ToList();

            // メソッドの戻り値であるエラーメッセージリストを結合する
            var errorMessageList = EnteredValueNullCheck(nullJudegeListModel).Concat(EnteredValueLengthCheck(lengthJudgeListModel)).ToList();
            if (sCRN0002ViewModel.EmployeeID != null)
            {
                errorMessageList = errorMessageList.Concat(CorrelationCheck(sCRN0002ViewModel)).ToList();
            }

            // ToDo別メソッドに分ける
            if (errorMessageList == null)
            {
                EmployeeInfoDAO entryValues = new EmployeeInfoDAO();

                entryValues.EmployeeID = sCRN0002ViewModel.EmployeeID;
                entryValues.AffiliationCd = sCRN0002ViewModel.AffiliationCd;
                entryValues.PositionCd = sCRN0002ViewModel.PositionCd;
                entryValues.EmployeeNm = sCRN0002ViewModel.EmployeeName;
                entryValues.Gender = sCRN0002ViewModel.Gender;
                entryValues.BirthDay = Convert.ToDateTime(sCRN0002ViewModel.BirthDay);
                entryValues.ForeignNationality = sCRN0002ViewModel.ForeignNationality;
                entryValues.BaseSalary = Convert.ToDecimal(sCRN0002ViewModel.BaseSalary);
                entryValues.Memo = null;
                entryValues.Memo = sCRN0002ViewModel.Memo;
                entryValues.insertUser = CommonConstants.MOD_USER_ID;
                entryValues.insertTime = DateTime.Now;
                entryValues.updateUser = CommonConstants.MOD_USER_ID;
                entryValues.updateTime = DateTime.Now;

                if (errorMessageList == null)
                {
                    _ev8001Logic.Register(entryValues);
                }
            }
            return new SCRN0002ViewModel()
            {
                AffiliationList = sCRN0002ViewModel.AffiliationList,
                PositionList = sCRN0002ViewModel.PositionList,
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
            var NullTargetModels = new List<NullJudgeListModel>
            {
            new NullJudgeListModel(request.EmployeeID),
            new NullJudgeListModel(request.AffiliationCd),
            new NullJudgeListModel(request.PositionCd),
            new NullJudgeListModel(request.EmployeeName),
            new NullJudgeListModel(request.Gender.ToString()),
            new NullJudgeListModel(request.BirthDay),
            new NullJudgeListModel(request.BaseSalary)
            };
            return NullTargetModels;
        }

        public List<LengthJudgeListModel> LengthValueCheckSet(SCRN0002ViewModel request)
        {
            // ToDo部署なども追加
            var LengthTargetModels = new List<LengthJudgeListModel>
            {
            new LengthJudgeListModel(request.EmployeeID,8),
            new LengthJudgeListModel(request.AffiliationCd,6),
            new LengthJudgeListModel(request.PositionCd,4),
            new LengthJudgeListModel(request.EmployeeName,32),
            new LengthJudgeListModel(request.Gender.ToString(),1),
            new LengthJudgeListModel(request.BirthDay,10),
            new LengthJudgeListModel(request.BaseSalary,8)
            };
            return LengthTargetModels;
        }

        /// <summary>
        /// 入力判定時単項目チェックを呼び出すメソッド
        /// </summary>
        /// <param name="entryJudgeListModel">未入力チェック対象</param>
        /// <returns>未入力チェックとエラーメッセージ格納を行う</returns>
        private List<DisplayDinoteErrMessage> EnteredValueNullCheck(List<NullJudgeListModel> entryJudgeListModel)
        {
            ValueJudge valueJudge = new ValueJudge();
            var errorMessageList = new List<DisplayDinoteErrMessage>();
            var judgeResult = entryJudgeListModel.Select(item => valueJudge.EnteredNullJudge(item.EmployeeDate));
            ErrorMessageConstants errorMessages = new ErrorMessageConstants();
            int countNum = 0;
            foreach (var i in judgeResult)
            {
                // 社員IDの入力値チェック
                if (i == false)
                {
                    errorMessageList.Add(
                        new DisplayDinoteErrMessage()
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
        /// <param name="checkTargetList">桁数チェック対象</param>
        /// <returns>桁数判定メソッド呼び出しとエラーメッセージ格納を行う</returns>
        private List<DisplayDinoteErrMessage> EnteredValueLengthCheck(List<LengthJudgeListModel> checkTargetList)
        {
            ValueJudge valueJudge = new ValueJudge();
            var errorMessageList = new List<DisplayDinoteErrMessage>();
            ErrorMessageConstants errorMessages = new ErrorMessageConstants();
            var judgeResult = checkTargetList.Select(item => valueJudge.EnteredValueLengthJudge(item.EmployeeDate, item.MaxJudgedigit));

            int countNum = 0;
            foreach (var i in judgeResult)
            {
                (List<string> valueResult, bool valueResultBool) = valueJudge.ValueCheck(checkTargetList[countNum].MinJudgedigit, checkTargetList[countNum].MaxJudgedigit);
                // 社員IDの入力値チェック
                if (i == false)
                {

                    errorMessageList.Add(
                        new DisplayDinoteErrMessage()
                        {
                            MessageID = "COMMSG0001",
                            DisplayForMessage = errorMessages.itemNameMessageList[countNum] + errorMessages.instructionMessageList[1]
                        });
                }
                countNum++;
            }
            return errorMessageList;
        }

        /// <summary>
        /// 相関チェックメソッド
        /// </summary>
        /// <param name="sCRN0002ViewModel">登録用入力値</param>
        /// <returns>エラーメッセージ格納も行う</returns>
        private List<DisplayDinoteErrMessage> CorrelationCheck(SCRN0002ViewModel sCRN0002ViewModel)
        {
            CorrelationJudge correlationJudge = new CorrelationJudge();

            var errorMessageList = new List<DisplayDinoteErrMessage>();
            ErrorMessageConstants errorMessages = new ErrorMessageConstants();
            var SqlList = _ev8001Logic.FindByPrimaryKey(sCRN0002ViewModel.EmployeeID);
            if (true == correlationJudge.IdCorrelationIdJudge(SqlList))
            {
                errorMessageList.Add(
                      new DisplayDinoteErrMessage()
                      {
                          MessageID = "COMMSG0001",
                          DisplayForMessage = errorMessages.correlationList[0]
                      });

                if (false == correlationJudge.AfCorrelationJudge(SqlList, sCRN0002ViewModel))
                {
                    errorMessageList.Add(
                            new DisplayDinoteErrMessage()
                            {
                                MessageID = "DBMST00001",
                                DisplayForMessage = "部署" + errorMessages.correlationList[1] + SqlList[0].AffiliationCd + errorMessages.correlationList[2]
                            });
                }
                if (false == correlationJudge.PosiCorrelationJudge(SqlList, sCRN0002ViewModel))
                {
                    errorMessageList.Add(
                            new DisplayDinoteErrMessage()
                            {
                                MessageID = "DBMST00001",
                                DisplayForMessage = "役職" + errorMessages.correlationList[1] + SqlList[0].PositionCd + errorMessages.correlationList[2]
                            });
                }
            }
            return errorMessageList;
        }
    }
}
