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
        /// <summary>EV8001Logicのヘルパー</summary>
        /// <remarks>EV8001Logicのヘルパー</remarks>
        private readonly IEV8001Logic _ev8001Logic = null;
        /// <summary>EV8002Logicのヘルパー</summary>
        /// <remarks>EV8002Logicのヘルパー</remarks>
        private readonly IEV8002Logic _ev8002Logic = null;
        /// <summary>EV8003Logicのヘルパー</summary>
        /// <remarks>EV8003Logicのヘルパー</remarks>
        private readonly IEV8003Logic _ev8003Logic = null;
        /// <summary>
        /// EV0002Helperのコンストラクタ
        /// </summary>
        /// <remarks>
        /// DIの実施
        /// </remarks>
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
            SCRN0002ViewModel sCRN0002ViewModel = new SCRN0002ViewModel();

            // ドロップダウンリストセット
            (sCRN0002ViewModel.AffiliationList, sCRN0002ViewModel.PositionList) = DropDownListSet();
            // 性別初期値セット
            sCRN0002ViewModel.Gender = 1;
            return sCRN0002ViewModel;
        }

        /// <summary>
        /// 新規登録時メソッド
        /// </summary>
        /// <returns>
        /// 入力値チェックメソッドを実行する
        /// </returns>
        /// <param name="sCRN0002ViewModel">入力値</param>
        public SCRN0002ViewModel Entry(SCRN0002ViewModel sCRN0002ViewModel)
        {
            List<NullJudgeListModel> nullJudegeTargetList = NullValueCheckSet(sCRN0002ViewModel);
            List<LengthJudgeListModel> lengthJudgeListModel = LengthValueCheckSet(sCRN0002ViewModel);

            // ドロップダウンリストセット
            (sCRN0002ViewModel.AffiliationList, sCRN0002ViewModel.PositionList) = DropDownListSet();

            // メソッドの戻り値であるエラーメッセージリストを結合する
            var errorMessageList = EnteredValueNullCheck(nullJudegeTargetList).Concat(EnteredValueLengthCheck(lengthJudgeListModel)).ToList();
            if (sCRN0002ViewModel.EmployeeID != null)
            {
                errorMessageList = errorMessageList.Concat(CorrelationCheck(sCRN0002ViewModel)).ToList();
            }


            if (!errorMessageList.Any())
            {
                _ev8001Logic.Register(EntryInfoSet(sCRN0002ViewModel));
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
        /// <returns>未入力判定する値をlistに格納する</returns>
        /// <param name="request">入力値</param>
        public List<NullJudgeListModel> NullValueCheckSet(SCRN0002ViewModel request)
        {
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
        /// <returns>未入力チェックとエラーメッセージ格納を行う</returns>
        /// <param name="entryJudgeListModel">未入力チェック対象</param>
        private List<DisplayViewErrMessage> EnteredValueNullCheck(List<NullJudgeListModel> entryJudgeListModel)
        {
            ValueJudge valueJudge = new ValueJudge();
            var errorMessageList = new List<DisplayViewErrMessage>();
            var judgeResult = entryJudgeListModel.Select(item => valueJudge.EnteredNullJudge(item.EmployeeDate));
            ErrorMessageConstants errorMessages = new ErrorMessageConstants();
            int countNum = 0;
            foreach (var i in judgeResult)
            {
                // 社員IDの入力値チェック
                if (i == false)
                {
                    errorMessageList.Add(
                        new DisplayViewErrMessage()
                        {
                            MessageID = "COMMSG0001",
                            DisplayForMessage = errorMessages.ItemNameMessageList[countNum] + errorMessages.InstructionMessageList[0],
                        });
                }
                countNum++;
            }
            return errorMessageList;
        }

        /// <summary>
        /// 桁数判定単項目チェックを呼び出すメソッド
        /// </summary>
        /// <returns>桁数判定メソッド呼び出しとエラーメッセージ格納を行う</returns>
        /// <param name="checkTargetList">桁数チェック対象</param>
        private List<DisplayViewErrMessage> EnteredValueLengthCheck(List<LengthJudgeListModel> checkTargetList)
        {
            ValueJudge valueJudge = new ValueJudge();
            var errorMessageList = new List<DisplayViewErrMessage>();
            ErrorMessageConstants errorMessages = new ErrorMessageConstants();
            var judgeResult = checkTargetList.Select(item => valueJudge.InputValueLengthJudge(item.EmployeeDate, item.MaxJudgedigit));

            int countNum = 0;
            foreach (var item in judgeResult)
            {
                (List<string> valueResult, bool valueResultBool) = valueJudge.ValueCheck(checkTargetList[countNum].MinJudgedigit, checkTargetList[countNum].MaxJudgedigit);
                // 社員IDの入力値チェック
                if (!item)
                {
                    errorMessageList.Add(
                        new DisplayViewErrMessage()
                        {
                            MessageID = "COMMSG0001",
                            DisplayForMessage = errorMessages.ItemNameMessageList[countNum] + errorMessages.InstructionMessageList[1]
                        });
                }
                countNum++;
            }
            return errorMessageList;
        }

        /// <summary>
        /// 相関チェックメソッド
        /// </summary>
        /// <returns>エラーメッセージ格納も行う</returns>
        /// <param name="sCRN0002ViewModel">登録用入力値</param>
        private List<DisplayViewErrMessage> CorrelationCheck(SCRN0002ViewModel sCRN0002ViewModel)
        {
            var errorMessageList = new List<DisplayViewErrMessage>();
            ErrorMessageConstants errorMessages = new ErrorMessageConstants();

            var sqlList = _ev8001Logic.FindByPrimaryKey(sCRN0002ViewModel.EmployeeID);
            if (true == CorrelationJudge.IdCorrelationIdJudge(sqlList))
            {
                errorMessageList.Add(
                      new DisplayViewErrMessage()
                      {
                          MessageID = "COMMSG0001",
                          DisplayForMessage = errorMessages.CorrelationList[0]
                      });

                if (!CorrelationJudge.AfCorrelationJudge(sqlList, sCRN0002ViewModel.AffiliationCd))
                {
                    errorMessageList.Add(
                            new DisplayViewErrMessage()
                            {
                                MessageID = "DBMST00001",
                                DisplayForMessage = "部署" + errorMessages.CorrelationList[1] + sqlList[0].AffiliationCd + errorMessages.CorrelationList[2]
                            });
                }
                if (!CorrelationJudge.PosiCorrelationJudge(sqlList, sCRN0002ViewModel.PositionCd))
                {
                    errorMessageList.Add(
                            new DisplayViewErrMessage()
                            {
                                MessageID = "DBMST00001",
                                DisplayForMessage = "役職" + errorMessages.CorrelationList[1] + sqlList[0].PositionCd + errorMessages.CorrelationList[2]
                            });
                }
            }
            return errorMessageList;
        }

        /// <summary>
        /// ドロップダウンリストを設定するメソッド
        /// </summary>
        /// <returns>SQLからリスト情報を取得する</returns>
        private (IList<AffiliationInfo>, IList<PositionInfo>) DropDownListSet()
        {
            var AffiliationValues = _ev8002Logic.FindAll();
            var PositionValues = _ev8003Logic.FindAll();

            var AffiliationList = AffiliationValues.Select(item => new AffiliationInfo
            {
                AffiliationCd = item.AffiliationCd,
                AffiliationNm = item.ManagementNm,
            }).ToList();

            var PositionList = PositionValues.Select(item => new PositionInfo
            {
                PositionCd = item.PositionCd,
                PositionNm = item.PositionNm,
            }).ToList();

            return (AffiliationList, PositionList);
        }

        /// <summary>
        /// 登録情報を設定する
        /// </summary>
        /// <param name="sCRN0002ViewModel">入力値</param>
        /// <returns>入力値をEmplyeeInfoDAOに格納する</returns>
        private EmployeeInfoDAO EntryInfoSet(SCRN0002ViewModel sCRN0002ViewModel)
        {
            EmployeeInfoDAO entryValues = new EmployeeInfoDAO()
            {
                EmployeeID = sCRN0002ViewModel.EmployeeID,
                AffiliationCd = sCRN0002ViewModel.AffiliationCd,
                PositionCd = sCRN0002ViewModel.PositionCd,
                EmployeeNm = sCRN0002ViewModel.EmployeeName,
                Gender = sCRN0002ViewModel.Gender,
                BirthDay = Convert.ToDateTime(sCRN0002ViewModel.BirthDay),
                ForeignNationality = sCRN0002ViewModel.ForeignNationality,
                BaseSalary = Convert.ToDecimal(sCRN0002ViewModel.BaseSalary),
                Memo = sCRN0002ViewModel.Memo,
                insertUser = CommonConstants.MOD_USER_ID,
                insertTime = DateTime.Now,
                updateUser = CommonConstants.MOD_USER_ID,
                updateTime = DateTime.Now,
            };
            return entryValues;
        }
    }
}
