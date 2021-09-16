using EmployeeManagement.Judge;
using EmployeeManagement.LogicDTO;
using EmployeeManagement.ViewModel;
using EmployeeManagementWebUITest.JudgeTest.Mock;
using NUnit.Framework;
using System.Collections.Generic;

namespace EmployeeManagementWebUITest.JudgeTest
{
    [TestFixture]
    class CorrelationJudgeTest
    {
        /// <summary>
        /// 社員ID相関チェックメソッドテスト
        /// </summary>
        /// <remarks>結果True時</remarks>
        /// <param name="value">社員ID</param>
        [TestCase("")]
        public void IdCorrelationIdJudgeTrueTest(string value)
        {
            var List = new List<EmployeeInfoDAO>
            {
                new EmployeeInfoDAO() {PositionCd = value }
            };


　          var testResult = CorrelationJudge.IdCorrelationIdJudge(List);

            Assert.AreEqual(false, testResult);
        }

        /// <summary>
        /// 社員ID相関チェックメソッドテスト
        /// </summary>
        /// <remarks>結果False時</remarks>
        /// <param name="value">社員ID</param>
        [TestCase("1")]
        public void IdCorrelationIdJudgeFalseTest(string value)
        {
            var List = new List<EmployeeInfoDAO>
            {
                new EmployeeInfoDAO() {EmployeeID = value }
            };

            var testResult = CorrelationJudge.IdCorrelationIdJudge(List);

            Assert.AreEqual(true, testResult);
        }

        /// <summary>
        /// 部署相関チェックメソッドテスト
        /// </summary>
        /// <remarks>結果がTrue時</remarks>
        /// <param name="inputValue">入力値</param>
        /// <param name="sqlValue">SQL値</param>
        [TestCase("01","01")]
        public void AfCorrelationJudgeTrueTest(string inputValue,string sqlValue)
        {
            var affirliationList = new List<AffiliationDAO>
            {
                new AffiliationDAO() {AffiliationCd =sqlValue }
            };

            var sCRN0002ViewModelMock = new SCRN0002ViewModelMock()
            {
                SCRN2ViewModelMock = new SCRN0002ViewModel()
                {
                    AffiliationCd = inputValue
                }
            };

            var testResult = CorrelationJudge.AfCorrelationJudge(affirliationList,sCRN0002ViewModelMock.SCRN2ViewModelMock.AffiliationCd);
           
            Assert.AreEqual(true, testResult);
        }

        /// <summary>
        /// 部署相関チェックメソッドテスト
        /// </summary>
        /// <remarks>結果がfalse時</remarks>
        /// <param name="inputValue">入力値</param>
        /// <param name="sqlValue">SQL値</param>
        [TestCase("01", "00")]
        public void AfCorrelationJudgeFalseTest(string inputValue, string sqlValue)
        {
            var List = new List<AffiliationDAO>
            {
                new AffiliationDAO() {AffiliationCd =sqlValue }
            };

            var sCRN0002ViewModelMock = new SCRN0002ViewModelMock()
            {
                SCRN2ViewModelMock = new SCRN0002ViewModel()
                {
                    AffiliationCd = inputValue
                }
            };

            var testResult = CorrelationJudge.AfCorrelationJudge(List, sCRN0002ViewModelMock.SCRN2ViewModelMock.AffiliationCd);
           
            Assert.AreEqual(false, testResult);
        }


        /// <summary>
        /// 役職相関チェックメソッドテスト
        /// </summary>
        /// <remarks>入力値がマスタに格納されている場合</remarks>
        /// <param name="inputValue">入力値</param>
        /// <param name="sqlValue">SQL値</param>
        [TestCase("01", "01")]
        public void PosiCorrelationJudgeTrueTest(string inputValue, string sqlValue)
        {
            var List = new List<PositionDAO>
            {
                new PositionDAO() {PositionCd =sqlValue }
            };

            // 引数からSCRN002のインスタンスのPositionCdに値を渡す
            var sCRN0002ViewModelMock = new SCRN0002ViewModelMock()
            {
                SCRN2ViewModelMock = new SCRN0002ViewModel()
                {
                    PositionCd = inputValue
                }
            };
            // それぞれの値をテスト対象メソッドに渡す
            var testResult = CorrelationJudge.PosiCorrelationJudge(List, sCRN0002ViewModelMock.SCRN2ViewModelMock.PositionCd);
           
            Assert.AreEqual(true, testResult);
        }

        /// <summary>
        /// 役職相関チェックメソッドテスト
        /// </summary>
        /// <remarks>結果がfalse時</remarks>
        /// <param name="inputValue">入力値</param>
        /// <param name="sqlValue">SQL値</param>
        [TestCase("01", "00")]
        public void PosiCorrelationJudgeFalseTest(string inputValue, string sqlValue)
        {
            var List = new List<PositionDAO>
            {
                new PositionDAO() {PositionCd =sqlValue }
            };

            var sCRN0002ViewModelMock = new SCRN0002ViewModelMock()
            {
                SCRN2ViewModelMock = new SCRN0002ViewModel()
                {
                    PositionCd = inputValue
                }
            };
           
            var testResult = CorrelationJudge.PosiCorrelationJudge(List, sCRN0002ViewModelMock.SCRN2ViewModelMock.PositionCd);
            
            Assert.AreEqual(false, testResult);
        }
    }
}
