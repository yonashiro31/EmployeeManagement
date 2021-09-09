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
        /// <remarks>未入力メソッドのテストを行う</remarks>
        [TestCase("", "test")]
        public void EnteredNullJudgeTest(string nullValue,string notNullValue )
        {
            ValueJudge testTarget = new ValueJudge();
            var nullResult = testTarget.EnteredNullJudge(nullValue);
            var notNullResult = testTarget.EnteredNullJudge(notNullValue);

            Assert.AreEqual(true, notNullResult);
            Assert.AreEqual(false, nullResult);
        }

        /// <summary>
        /// 桁数チェックメソッドのテスト
        /// </summary>
        /// <remarks>最大桁数と入力値の比較を行う</remarks>
        /// <param name="xuRongValue">許容入力値</param>
        /// <param name="notXuRongValue">非許容入力値</param>
        /// <param name="maxDigit">最大桁数</param>
        [TestCase("test", "test1" , 4)]
        public void EnteredValueLengthJudgeTest(string xuRongValue,string notXuRongValue,int maxDigit)
        {
            ValueJudge testTarget = new ValueJudge();
            var trueResult = testTarget.EnteredValueLengthJudge(xuRongValue , maxDigit);
            var falseResult = testTarget.EnteredValueLengthJudge(notXuRongValue, maxDigit);

            Assert.AreEqual(true, trueResult);
            Assert.AreEqual(false, falseResult);
        }

        [TestCase( )]
        public void ValueCheckTest(int min, int max)
        {
            ValueJudge testTarget = new ValueJudge();
            
        }

        /// <summary>
        /// 部署情報のチェッククラステスト
        /// </summary>
        /// <remarks></remarks>
        [TestCase("00","01")]
        public void AffiliationNmCheckTest(string shouldValue,string notShouldValue)
        {
            var affiliationDAOMock = new AffiliationDAOMock
            {
                TestAffiliationDAO = new AffiliationDAO()
                {
                    BrunchCd = shouldValue,
                    GroupCd = shouldValue,
                }
            };
            var testTarget = new ValueJudge();
            var Result01 = testTarget.AffiliationNmCheck(affiliationDAOMock.TestAffiliationDAO);

            new AffiliationDAOMock
            {
                TestAffiliationDAO = new AffiliationDAO()
                {

                }
            };


        }
    }
}
