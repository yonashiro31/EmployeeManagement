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
    public class ValueJudgeTest
    {
        /// <summary>
        /// 未入力メソッドテスト
        /// </summary>
        /// <remarks>結果True時</remarks>
        /// <param name="inputValue">入力値</param>
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
        /// <param name="inputValue">入力値</param>
        [TestCase("")]
        public void FalseNullJudgeTest(string inputValue)
        {
            var testResult = ValueJudge.EnteredNullJudge(inputValue);

            Assert.AreEqual(false, testResult);
        }

        /// <summary>
        /// 桁数チェックメソッドのテスト
        /// </summary>
        /// <remarks>入力値が桁数以内の場合</remarks>
        /// <param name="inputValue">入力値</param>
        /// <param name="maxDigit">最大桁数</param>
        /// <param name="minDigit">最小桁数</param>
        [TestCase("test", 4 , 4)]
        [TestCase("", 0 , 0)]
        public void InputValueLengthJudgeTrueTest(string inputValue, int maxDigit , int minDigit)
        {
            var testResult = ValueJudge.InputValueLengthJudge(inputValue, maxDigit , minDigit);

            Assert.True(testResult);
        }

        /// <summary>
        /// 桁数チェックメソッドのテスト
        /// </summary>
        /// <remarks>結果False時</remarks>
        /// <param name="inputValue">入力値</param>
        /// <param name="maxDigit">最大桁数</param>
        /// <param name="minDigit">最小桁数</param>
        [TestCase("test1", 4 , 1)]
        [TestCase("test", 4, 5)]
        public void InputValueLengthJudgeFalseTest(string inputValue, int maxDigit , int minDigit)
        {
            var testResult = ValueJudge.InputValueLengthJudge(inputValue, maxDigit , minDigit);

            Assert.False(testResult);
        }

        /// <summary>
        /// 入力値の種別を判断するメソッド
        /// </summary>
        /// <remarks>IDが入力された場合</remarks>
        /// <param name="min">入力値の最小許容桁数</param>
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
        /// <remarks>氏名が入力された場合</remarks>
        /// <param name="min">入力値の最小許容桁数</param>
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
        /// <remarks>生年月日が入力された場合</remarks>
        /// <param name="min">入力値の最小許容桁数</param>
        /// <param name="max">入力値の最大許容桁数</param>
        [TestCase(9,10)]
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
        /// <remarks>基本給料が入力された場合</remarks>
        /// <param name="min">入力値の最小許容桁数</param>
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
        /// <remarks>どれにも当てはまらない場合</remarks>
        /// <param name="min">入力値の最小許容桁数</param>
        /// <param name="max">入力値の最大許容桁数</param>
        [TestCase(1, 1111)]
        public void ValueCheckFalseTest(int min, int max)
        {
            (var testResultList, var testResult) = ValueJudge.ValueCheck(min, max);
            var result = testResultList.Count;
            Assert.AreEqual(0,result);
            Assert.False(testResult);
        }

        /// <summary>
        /// 部署情報のチェッククラステスト
        /// </summary>
        /// <remarks>ブランチネーム返却時</remarks>
        /// <param name="brunchCd">部門コード</param>
        /// <param name="groupCd">グループコード</param>
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
        /// <param name="brunchCd">部門コード</param>
        /// <param name="groupCd">グループコード</param>
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
        /// <param name="brunchCd">部門コード</param>
        /// <param name="groupCd">グループコード</param>
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

        /// <summary>
        /// 数値化文字列か判別するメソッドテストクラス（True時）
        /// </summary>
        /// <remarks>数値を想定する場合第二引数にtrue文字列を想定する場合はfalseを入力する</remarks>
        /// <param name="targetValue">入力値</param>
        /// <param name="nullPatternResult">未入力時の返却値</param>
        [TestCase("2000/01/01" , true)]
        [TestCase("10.00", true)]
        [TestCase("1", true)]
        [TestCase("", true)]
        public void NumOrCharaTrueJudge(string targetValue, bool nullPatternResult)
        {
            var testResult = ValueJudge.NumOrCharaJudge(targetValue , nullPatternResult);
            Assert.IsTrue(testResult);
        }

        /// <summary>
        /// 数値化文字列か判別するメソッドテストクラス（False時）
        /// </summary>
        /// <remarks>数値を想定する場合第二引数にtrue文字列を想定する場合はfalseを入力する</remarks>
        /// <param name="targetValue">入力値</param>
        /// <param name="nullPatternResult">未入力時の返却値</param>
        [TestCase("", false)]
        [TestCase("テスト", false)]
        public void NumOrCharaFalseJudge(string targetValue, bool nullPatternResult)
        {
            var testResult = ValueJudge.NumOrCharaJudge(targetValue, nullPatternResult);
            Assert.IsFalse(testResult);
        }

        /// <summary>
        /// 生年月日が存在する値か判定するメソッドテストクラス（True時）
        /// </summary>
        /// <remarks>存在する場合Trueを返す</remarks>
        [TestCase("2000/01/01")]
        [TestCase("")]
        public void DateTimeJudgeTrueTest(string targetDateTime)
        {
            var testResult = ValueJudge.DateTimeJudge(targetDateTime);
            Assert.IsTrue(testResult);
        }

        /// <summary>
        /// 生年月日が存在する値か判定するメソッドテストクラス（False時）
        /// </summary>
        /// <remarks>存在する場合Falseを返す</remarks>
        [Test]
        public void DateTimeJudgeFalseTest()
        {
            var targetDateTime = "9999/99/99";
            var testResult = ValueJudge.DateTimeJudge(targetDateTime);
            Assert.IsFalse(testResult);
        }
    }
}
