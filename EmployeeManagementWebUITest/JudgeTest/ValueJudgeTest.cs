using EmployeeManagement.Constants;
using EmployeeManagement.Judge;
using EmployeeManagement.LogicDTO;
using EmployeeManagementWebUITest.ControllerTest.Mock;
using NUnit.Framework;
using System.Collections.Generic;

namespace EmployeeManagementWebUITest.JudgeTest
{
    /// <summary>
    /// 単項目チェッククラスのテストクラス
    /// </summary>
    /// <remarks>単項目チェックを行う</remarks>
    [TestFixture]
    class ValueJudgeTest
    {
        /// <summary>
        /// 未入力メソッドテスト
        /// </summary>
        /// <remarks>結果True時</remarks>
        [TestCase("test")]
        public void TrueNullJudgeTest(string inputValue)
        {
            var testResult = ValueJudge.EnteredNullJudge(inputValue);

            Assert.AreEqual(true, testResult);
        }

        /// <summary>
        /// 未入力メソッドテスト
        /// </summary>
        /// <remarks>結果False時</remarks>
        [TestCase("")]
        public void FalseNullJudgeTest(string enteredValue)
        {
            var testResult = ValueJudge.EnteredNullJudge(enteredValue);

            Assert.AreEqual(false, testResult);
        }

        /// <summary>
        /// 桁数チェックメソッドのテスト
        /// </summary>
        /// <remarks>入力値が桁数以内の場合</remarks>
        /// <param name="inputValue">入力値</param>
        /// <param name="maxDigit">最大桁数</param>
        [TestCase("test", 4)]
        [TestCase("", 0)]
        public void InputValueLengthJudgeTrueTest(string inputValue, int maxDigit)
        {
            var testResult = ValueJudge.InputValueLengthJudge(inputValue, maxDigit);

            Assert.True(testResult);
        }

        /// <summary>
        /// 桁数チェックメソッドのテスト
        /// </summary>
        /// <remarks>結果False時</remarks>
        /// <param name="inputValue">入力値</param>
        /// <param name="maxDigit">最大桁数</param>
        [TestCase("test1", 4)]
        
        public void InputValueLengthJudgeFalseTest(string inputValue, int maxDigit)
        {
            var testResult = ValueJudge.InputValueLengthJudge(inputValue, maxDigit);

            Assert.False(testResult);
        }

        /// <summary>
        /// 入力値の種別を判断するメソッド
        /// </summary>
        /// IDが入力された場合
        /// <param name="min">入力値の最少許容桁数</param>
        /// <param name="max">入力値の最大許容桁数</param>
        [TestCase(8,8)]
        public void ValueCheckIDTest(int min, int max)
        {
            var testMessageList = new List<string>
            {
                ErrorMessageConstants.ID_MESSAGE
            };

            (var testResultList, var testResult) = ValueJudge.ValueCheck(min, max);
            Assert.AreEqual(testMessageList,testResultList);
            Assert.True(testResult);
        }

        /// <summary>
        /// 種別の氏名を判断するメソッド
        /// </summary>
        /// 氏名が入力された場合
        /// <param name="min">入力値の最少許容桁数</param>
        /// <param name="max">入力値の最大許容桁数</param>
        [TestCase(1, 32)]
        public void ValueCheckNameTest(int min, int max)
        {
            var testMessageList = new List<string>
            {
                ErrorMessageConstants.NAME_MESSAGE
            };

            (var testResultList, var testResult) = ValueJudge.ValueCheck(min, max);
            Assert.AreEqual(testMessageList, testResultList);
            Assert.True(testResult);
        }

        /// <summary>
        /// 種別の生年月日を判断するメソッド
        /// </summary>
        /// 氏名が入力された場合
        /// <param name="min">入力値の最少許容桁数</param>
        /// <param name="max">入力値の最大許容桁数</param>
        [TestCase(9,9)]
        public void ValueCheckBirthTest(int min, int max)
        {
            var testMessageList = new List<string>
            {
                ErrorMessageConstants.BIRTHDAY_MESSAGE
            };
            (var testResultList, var testResult) = ValueJudge.ValueCheck(min, max);
            Assert.AreEqual(testMessageList, testResultList);
            Assert.True(testResult);
        }

        /// <summary>
        /// 基本給項目を判断するメソッド
        /// </summary>
        /// 氏名が入力された場合
        /// <param name="min">入力値の最少許容桁数</param>
        /// <param name="max">入力値の最大許容桁数</param>
        [TestCase(1, 8)]
        public void ValueCheckSaralyTest(int min, int max)
        {
            var testMessageList = new List<string>
            {
                ErrorMessageConstants.BASE_SALARY_MESSAGE
            };

            (var testResultList, var testResult) = ValueJudge.ValueCheck(min, max);
            Assert.AreEqual(testMessageList, testResultList);
            Assert.True(testResult);
        }

        /// <summary>
        /// 入力値を判断するメソッド
        /// </summary>
        /// 氏名が入力された場合
        /// <param name="min">入力値の最少許容桁数</param>
        /// <param name="max">入力値の最大許容桁数</param>
        [TestCase(1, 1111)]
        public void ValueCheckFalseTest(int min, int max)
        {
            (var testResultList, var testResult) = ValueJudge.ValueCheck(min, max);
            var result = testResultList.Count;
            Assert.AreEqual(0,result);
            Assert.False(testResult);
        }

        // ToDo下記3メソッド名変更予定

        /// <summary>
        /// 部署情報のチェッククラステスト
        /// </summary>
        /// <remarks>ブランチネーム返却時</remarks>
        [TestCase("01", "00")]
        [TestCase("01", "01")]
        public void AffiliationAfNmCheckTest(string brunchCd, string groupCd)
        {
            var affiliationDAOMock = new AffiliationDAOMock
            {
                TestAffiliationDAO = new AffiliationDAO()
                {
                    BrunchCd = brunchCd,
                    GroupCd = groupCd,
                    BrunchNm = "BrunchNm",
                    GroupNm = "GroupNm",
                    ManagementNm = "ManagementNm"
                }
            };
            var testResult = ValueJudge.AffiliationNmCheck(affiliationDAOMock.TestAffiliationDAO);

            Assert.AreEqual("BrunchNm", testResult);
        }

        /// <summary>
        /// 部署情報のチェッククラステスト
        /// </summary>
        /// <remarks>グループネーム返却時</remarks>
        [TestCase("00", "01")]
        public void AffiliationGoupNmCheckTest(string brunchCd, string groupCd)
        {
            var affiliationDAOMock = new AffiliationDAOMock
            {
                TestAffiliationDAO = new AffiliationDAO()
                {
                    BrunchCd = brunchCd,
                    GroupCd = groupCd,
                    BrunchNm = "BrunchNm",
                    GroupNm = "GroupNm",
                    ManagementNm = "ManagementNm"
                }
            };
            var testResult = ValueJudge.AffiliationNmCheck(affiliationDAOMock.TestAffiliationDAO);

            Assert.AreEqual("GroupNm", testResult);
        }

        /// <summary>
        /// 部署情報のチェッククラステスト
        /// </summary>
        /// <remarks>マネージメントネーム返却時</remarks>
        [TestCase("00", "00")]
        public void AffiliationMnNmCheckTest(string brunchCd, string groupCd)
        {
            var affiliationDAOMock = new AffiliationDAOMock
            {
                TestAffiliationDAO = new AffiliationDAO()
                {
                    BrunchCd = brunchCd,
                    GroupCd = groupCd,
                    BrunchNm = "BrunchNm",
                    GroupNm = "GroupNm",
                    ManagementNm = "ManagementNm"
                }
            };
            var testResult = ValueJudge.AffiliationNmCheck(affiliationDAOMock.TestAffiliationDAO);

            Assert.AreEqual("ManagementNm", testResult);
        }
    }
}
