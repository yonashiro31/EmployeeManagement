using EmployeeManagement.Judge;
using EmployeeManagement.LogicDTO;
using EmployeeManagementWebUITest.ControllerTest.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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
        [TestCase("", "test")]
        public void trueNullJudgeTest(string inputValue )
        {
            ValueJudge testTarget = new ValueJudge();
            var testResult = testTarget.EnteredNullJudge(inputValue);

            Assert.AreEqual(true, testResult);
        }

        /// <summary>
        /// 未入力メソッドテスト
        /// </summary>
        /// <remarks>結果False時</remarks>
        [TestCase("", "test")]
        public void falseNullJudgeTest(string enteredValue)
        {
            ValueJudge testTarget = new ValueJudge();
            var testResult = testTarget.EnteredNullJudge(enteredValue);

            Assert.AreEqual(false, testResult);
        }

        /// <summary>
        /// 桁数チェックメソッドのテスト
        /// </summary>
        /// <remarks>結果True時</remarks>
        /// <param name="inputValue">入力値</param>
        /// <param name="maxDigit">最大桁数</param>
        [TestCase("test", 4)]
        public void InputValueLengthJudgeTrueTest(string inputValue,int maxDigit)
        {
            ValueJudge testTarget = new ValueJudge();
            var testResult = testTarget.InputValueLengthJudge(inputValue , maxDigit);

            Assert.AreEqual(true, testResult);
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
            ValueJudge testTarget = new ValueJudge();
            var testResult = testTarget.InputValueLengthJudge(inputValue, maxDigit);

            Assert.AreEqual(false, testResult);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        [TestCase( )]
        public void ValueCheckTest(int min, int max)
        {
            ValueJudge testTarget = new ValueJudge();
            
        }


        // ToDo下記3メソッド名変更予定

        /// <summary>
        /// 部署情報のチェッククラステスト
        /// </summary>
        /// <remarks>ブランチネーム返却時</remarks>
        [TestCase("01","00")]
        [TestCase("01", "01")]
        public void AffiliationNmCheckTest(string brunchCd,string groupCd)
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
            var testTarget = new ValueJudge();
            var testResult = testTarget.AffiliationNmCheck(affiliationDAOMock.TestAffiliationDAO);

            Assert.AreEqual("BrunchNm", testResult);
        }

        /// <summary>
        /// 部署情報のチェッククラステスト
        /// </summary>
        /// <remarks>グループネーム返却時</remarks>
        [TestCase("00", "01")]
        public void AffiliationNmCheckTest2(string brunchCd, string groupCd)
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
            var testTarget = new ValueJudge();
            var testResult = testTarget.AffiliationNmCheck(affiliationDAOMock.TestAffiliationDAO);

            Assert.AreEqual("GroupNm", testResult);
        }

        /// <summary>
        /// 部署情報のチェッククラステスト
        /// </summary>
        /// <remarks>マネージメントネーム返却時</remarks>
        [TestCase("00", "00")]
        public void AffiliationNmCheckTest3(string brunchCd, string groupCd)
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
            var testTarget = new ValueJudge();
            var testResult = testTarget.AffiliationNmCheck(affiliationDAOMock.TestAffiliationDAO);

            Assert.AreEqual("ManagementNm", testResult);
        }
    }
}
