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
        /// <remarks>
        /// 初期表示時に実行する処理
        /// </remarks>
        /// <returns>
        /// 初期表示用ViewModel
        /// </returns>
        public SCRN0002ViewModel Init()
        {
            SCRN0002ViewModel sCRN0002ViewModel = new SCRN0002ViewModel();

            // ドロップダウンリストセット
            (sCRN0002ViewModel.AffiliationList, sCRN0002ViewModel.PositionList) = SetDropDownList();
            // 性別初期値セット
            sCRN0002ViewModel.Gender = CommonConstants.GENDER_MEN;
            return sCRN0002ViewModel;
        }

        /// <summary>
        /// 新規登録時メソッド
        /// </summary>
        /// <remarks>
        /// 入力値チェックメソッドを実行する
        /// </remarks>
        /// <param name="sCRN0002ViewModel">入力値</param>
        /// <returns>
        /// 登録値を返却する
        /// </returns>
        public SCRN0002ViewModel Entry(SCRN0002ViewModel sCRN0002ViewModel)
        {
            // 各種チェック用の値セット
            List<NullJudgeListModel> nullJudegeTargetList = SetNullCeckTarget(sCRN0002ViewModel);
            List<LengthJudgeListModel> lengthJudgeList = SetLengthCheckTarget(sCRN0002ViewModel);
            (var numberValueList, var characterValueList) = SetNumOrCharaCeckTarget(sCRN0002ViewModel);

            // ドロップダウンリストセット
            (sCRN0002ViewModel.AffiliationList, sCRN0002ViewModel.PositionList) = SetDropDownList();

            // メソッドの戻り値であるエラーメッセージリストを結合する
            var nullErrorMessageList = EnteredValueNullCheck(nullJudegeTargetList).ToList();
            var lengthErrorList = EnteredValueLengthCheck(lengthJudgeList).ToList();
            var numberErrorList = EnteredValueNumOrCharaCheck(numberValueList , characterValueList).ToList();

            var errorMessageList = nullErrorMessageList.Concat(lengthErrorList).ToList();
            errorMessageList = errorMessageList.Concat(numberErrorList).ToList();
            if (sCRN0002ViewModel.EmployeeID != null)
            {
                errorMessageList = errorMessageList.Concat(CorrelationCheck(sCRN0002ViewModel)).ToList();
            }

            if (!errorMessageList.Any())
            {
                _ev8001Logic.Register(SetEntryInfo(sCRN0002ViewModel));
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
        /// <remarks>未入力判定する項目を格納する</remarks>
        /// <param name="request">入力値</param>
        /// <returns>未入力判定する値を格納したlistを返却する</returns>
        public List<NullJudgeListModel> SetNullCeckTarget(SCRN0002ViewModel request)
        {
            var nullTargetList = new List<NullJudgeListModel>
            {
                new NullJudgeListModel(request.EmployeeID),
                new NullJudgeListModel(request.AffiliationCd),
                new NullJudgeListModel(request.PositionCd),
                new NullJudgeListModel(request.EmployeeName),
                new NullJudgeListModel(request.Gender.ToString()),
                new NullJudgeListModel(request.BirthDay),
                new NullJudgeListModel(request.BaseSalary)
            };
            return nullTargetList;
        }

        /// <summary>
        /// 未入力チェック用セットメソッド
        /// </summary>
        /// <remarks>桁数チェックを行う値を設定する</remarks>
        /// <param name="request">入力値</param>
        /// <returns>桁数チェック用の値リストを返却する</returns>
        public List<LengthJudgeListModel> SetLengthCheckTarget(SCRN0002ViewModel request)
        {
            var lengthTargetList = new List<LengthJudgeListModel>
            {
                new LengthJudgeListModel(request.EmployeeID,CommonConstants.ID_MAX_DIGITS,CommonConstants.ID_MIN_DIGITS),
                new LengthJudgeListModel(request.AffiliationCd,CommonConstants.AF_MAX_DIGITS,CommonConstants.AF_MIN_DIGITS),
                new LengthJudgeListModel(request.PositionCd,CommonConstants.POSI_MAX_DIGITS,CommonConstants.POSI_MIN_DIGITS),
                new LengthJudgeListModel(request.EmployeeName,CommonConstants.NAME_MAX_DIGITS,CommonConstants.NAME_MIN_DIGITS),
                new LengthJudgeListModel(request.Gender.ToString(),CommonConstants.GENDER_MAX_DIGITS,CommonConstants.GENDER_MIN_DIGITS),
                new LengthJudgeListModel(request.BirthDay,CommonConstants.BIRTH_DAY_MAX_DIGITS,CommonConstants.BIRTH_DAY_MIN_DIGITS),
                new LengthJudgeListModel(request.BaseSalary,CommonConstants.SALARY_MAX_DIGITS,CommonConstants.SALARY_MIN_DIGITS)
            };
            return lengthTargetList;
        }

        /// <summary>
        /// 数値判別判定入力値セットメソッド
        /// </summary>
        /// <remarks>未入力判定する項目を格納する</remarks>
        /// <param name="request">入力値</param>
        /// <returns>未入力判定する値を格納したlistを返却する</returns>
        public (List<JudgeTargetList>, List<JudgeTargetList>) SetNumOrCharaCeckTarget(SCRN0002ViewModel request)
        {
            var numTargetList = new List<JudgeTargetList>
            {
                new JudgeTargetList(request.EmployeeID,ErrorMessageConstants.ID_MESSAGE),
                new JudgeTargetList(request.AffiliationCd,ErrorMessageConstants.AF_MESSAGE),
                new JudgeTargetList(request.PositionCd,ErrorMessageConstants.POSI_MESSAGE),
                new JudgeTargetList(request.Gender.ToString(),ErrorMessageConstants.GENDER_MESSAGE),
                new JudgeTargetList(request.BaseSalary,ErrorMessageConstants.BASE_SALARY_MESSAGE)
            };

            var charaTargetList = new List<JudgeTargetList>
            {
                new JudgeTargetList(request.EmployeeName,ErrorMessageConstants.NAME_MESSAGE),
                new JudgeTargetList(request.BirthDay,ErrorMessageConstants.BIRTHDAY_MESSAGE),
            };
            return (numTargetList,charaTargetList);
        }

        /// <summary>
        /// 数値判別単項目チェックを呼び出すメソッド
        /// </summary>
        /// <remarks>数値チェックとエラーメッセージ格納を行う</remarks>
        /// <param name="numCheckTargetList">未入力チェック対象</param>
        /// <returns>数値チェックの結果リストとエラーメッセージリストを返す</returns>
        private List<DisplayViewErrMessage> EnteredValueNumOrCharaCheck(List<JudgeTargetList> numCheckTargetList,List<JudgeTargetList> charaCheckTargetList)
        {
            var errorMessageList = new List<DisplayViewErrMessage>();
            var judgeResult = numCheckTargetList.Select(item => ValueJudge.numOrcharaJudge(item.EmployeeDate , true));
            var numMessage = numCheckTargetList.Select(item => item.InputName).ToList();
            var judgeResult2 = charaCheckTargetList.Select(item => ValueJudge.numOrcharaJudge(item.EmployeeDate , false));
            var charaMessage = charaCheckTargetList.Select(item => item.InputName).ToList();
            ErrorMessageConstants errorMessages = new ErrorMessageConstants();
            int countNum = 0;
            foreach (var item in judgeResult)
            {
                // 社員IDの入力値チェック
                if (!item)
                {
                    errorMessageList.Add(
                        new DisplayViewErrMessage()
                        {
                            MessageID = "COMMSG0001",
                            DisplayForMessage = numMessage[countNum] + errorMessages.InstructionMessageList[2],
                        });
                }
                countNum++;
            }

            countNum = 0;
            foreach (var item in judgeResult2)
            {
                // 社員IDの入力値チェック
                if (item)
                {
                    errorMessageList.Add(
                        new DisplayViewErrMessage()
                        {
                            MessageID = "COMMSG0001",
                            DisplayForMessage = charaMessage[countNum] + errorMessages.InstructionMessageList[3],
                        });
                }
                countNum++;
            }


            return errorMessageList;
        }

        /// <summary>
        /// 入力判定時単項目チェックを呼び出すメソッド
        /// </summary>
        /// <remarks>未入力チェックとエラーメッセージ格納を行う</remarks>
        /// <param name="checkTargetList">未入力チェック対象</param>
        /// <returns>未入力チェックの結果リストとエラーメッセージリストを返す</returns>
        private List<DisplayViewErrMessage> EnteredValueNullCheck(List<NullJudgeListModel> checkTargetList)
        {
            var errorMessageList = new List<DisplayViewErrMessage>();
            var judgeResult = checkTargetList.Select(item => ValueJudge.EnteredNullJudge(item.EmployeeDate));
            ErrorMessageConstants errorMessages = new ErrorMessageConstants();
            int countNum = 0;
            foreach (var item in judgeResult)
            {
                // 社員IDの入力値チェック
                if (!item)
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
        /// 桁数判定時単項目チェックを呼び出すメソッド
        /// </summary>
        /// <remarks>桁数チェックとエラーメッセージ格納を行う</remarks>
        /// <param name="checkTargetList">桁数チェック対象</param>
        /// <returns>桁数チェックの結果リストとエラーメッセージリストを返す</returns>
        private List<DisplayViewErrMessage> EnteredValueLengthCheck(List<LengthJudgeListModel> checkTargetList)
        {
            var errorMessageList = new List<DisplayViewErrMessage>();
            ErrorMessageConstants errorMessages = new ErrorMessageConstants();
            var judgeResult = checkTargetList.Select(item => ValueJudge.InputValueLengthJudge(item.EmployeeDate, item.MaxJudgedigit ,item.MinJudgedigit));

            int countNum = 0;
            foreach (var item in judgeResult)
            {
                (List<string> valueResult, bool valueResultBool) = ValueJudge.ValueCheck(checkTargetList[countNum].MinJudgedigit, checkTargetList[countNum].MaxJudgedigit);
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
        /// <remarks>相関チェックの実施とエラーメッセージリストの設定を行う</remarks>
        /// <param name="sCRN0002ViewModel">登録用入力値</param>
        /// <returns>エラーメッセージを返す</returns>
        private List<DisplayViewErrMessage> CorrelationCheck(SCRN0002ViewModel sCRN0002ViewModel)
        {
            var errorMessageList = new List<DisplayViewErrMessage>();
            ErrorMessageConstants errorMessages = new ErrorMessageConstants();
            var sqlList = _ev8001Logic.FindByPrimaryKey(sCRN0002ViewModel.EmployeeID);
            var affiliationValues = _ev8002Logic.FindAll();
            var positionValues = _ev8003Logic.FindAll();
            if (CorrelationJudge.IdCorrelationIdJudge(sqlList))
            {
                errorMessageList.Add(
                      new DisplayViewErrMessage()
                      {
                          MessageID = "COMMSG0001",
                          DisplayForMessage = errorMessages.CorrelationErrorList[0]
                      });

                if (!CorrelationJudge.AfCorrelationJudge(affiliationValues, sCRN0002ViewModel.AffiliationCd))
                {
                    errorMessageList.Add(
                            new DisplayViewErrMessage()
                            {
                                MessageID = "DBMST00001",
                                DisplayForMessage = "部署" + errorMessages.CorrelationErrorList[1] + affiliationValues[0].AffiliationCd + errorMessages.CorrelationErrorList[2]
                            });
                }
                if (!CorrelationJudge.PosiCorrelationJudge(positionValues, sCRN0002ViewModel.PositionCd))
                {
                    errorMessageList.Add(
                            new DisplayViewErrMessage()
                            {
                                MessageID = "DBMST00001",
                                DisplayForMessage = "役職" + errorMessages.CorrelationErrorList[1] + positionValues[0].PositionCd + errorMessages.CorrelationErrorList[2]
                            });
                }
            }
            return errorMessageList;
        }

        /// <summary>
        /// ドロップダウンリストを設定するメソッド
        /// </summary>
        /// <remarks>SQLからリスト情報を取得する</remarks>
        /// <returns>部署役職情報リストを返却する</returns>
        private (IList<AffiliationInfo>, IList<PositionInfo>) SetDropDownList()
        {
            var affiliationValues = _ev8002Logic.FindAll();
            var positionValues = _ev8003Logic.FindAll();

            var affiliationList = affiliationValues.Select(item => new AffiliationInfo
            {
                AffiliationCd = item.AffiliationCd,
                AffiliationNm = item.ManagementNm,
            }).ToList();

            var positionList = positionValues.Select(item => new PositionInfo
            {
                PositionCd = item.PositionCd,
                PositionNm = item.PositionNm,
            }).ToList();

            return (affiliationList, positionList);
        }

        /// <summary>
        /// 登録情報を設定する
        /// </summary>
        /// <remarks>入力値をEmplyeeInfoDAOに格納する</remarks>
        /// <param name="sCRN0002ViewModel">入力値</param>
        /// <returns>登録用社員情報を返却する</returns>
        private EmployeeInfoDAO SetEntryInfo(SCRN0002ViewModel sCRN0002ViewModel)
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
                InsertUser = CommonConstants.MOD_USER_ID,
                InsertTime = DateTime.Now,
                UpdateUser = CommonConstants.MOD_USER_ID,
                UpdateTime = DateTime.Now,
            };
            return entryValues;
        }
    }
}
